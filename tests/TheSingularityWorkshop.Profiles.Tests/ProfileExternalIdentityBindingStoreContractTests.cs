using System.Collections.Concurrent;
using TheSingularityWorkshop.Profiles;
using Xunit;

namespace TheSingularityWorkshop.Profiles.Tests;

public sealed class ProfileExternalIdentityBindingStoreContractTests
{
    [Fact]
    public async Task ExternalIdentityCanBeBoundToOnlyOneProfile()
    {
        var store = new InMemoryBindingStore();
        var external = new ExternalIdentityReference("https://issuer.example", "subject-1");
        var first = new ProfileExternalIdentityBinding(ProfileId.New(), external);
        var second = new ProfileExternalIdentityBinding(ProfileId.New(), external);

        Assert.True(await store.TryAddAsync(first));
        Assert.False(await store.TryAddAsync(second));

        var resolved = await store.FindByExternalIdentityAsync(external);
        Assert.Equal(first.ProfileId, resolved!.ProfileId);
    }

    [Fact]
    public async Task OneProfileCanHaveMultipleExternalIdentities()
    {
        var store = new InMemoryBindingStore();
        var profileId = ProfileId.New();
        var first = new ProfileExternalIdentityBinding(
            profileId, new ExternalIdentityReference("https://issuer-a.example", "subject-a"));
        var second = new ProfileExternalIdentityBinding(
            profileId, new ExternalIdentityReference("https://issuer-b.example", "subject-b"));

        Assert.True(await store.TryAddAsync(first));
        Assert.True(await store.TryAddAsync(second));

        var bindings = await store.FindByProfileAsync(profileId);
        Assert.Equal(2, bindings.Count);
        Assert.Contains(bindings, binding => binding.ExternalIdentity == first.ExternalIdentity);
        Assert.Contains(bindings, binding => binding.ExternalIdentity == second.ExternalIdentity);
    }

    [Fact]
    public async Task ConcurrentAddsCannotOverwriteTheWinningBinding()
    {
        var store = new InMemoryBindingStore();
        var external = new ExternalIdentityReference("https://issuer.example", "shared-subject");
        var attempts = Enumerable.Range(0, 32)
            .Select(_ => store.TryAddAsync(
                new ProfileExternalIdentityBinding(ProfileId.New(), external)).AsTask());

        var results = await Task.WhenAll(attempts);

        Assert.Single(results.Where(added => added));
        Assert.Equal(31, results.Count(added => !added));
        Assert.NotNull(await store.FindByExternalIdentityAsync(external));
    }

    [Fact]
    public async Task RemovingBindingUnlinksItWithoutImplyingAuditRetention()
    {
        var store = new InMemoryBindingStore();
        var external = new ExternalIdentityReference("https://issuer.example", "subject-1");
        var binding = new ProfileExternalIdentityBinding(ProfileId.New(), external);
        Assert.True(await store.TryAddAsync(binding));

        Assert.True(await store.RemoveAsync(external));
        Assert.False(await store.RemoveAsync(external));
        Assert.Null(await store.FindByExternalIdentityAsync(external));
    }

    private sealed class InMemoryBindingStore : IProfileExternalIdentityBindingStore
    {
        private readonly ConcurrentDictionary<ExternalIdentityReference, ProfileExternalIdentityBinding> _bindings = new();

        public ValueTask<bool> TryAddAsync(
            ProfileExternalIdentityBinding binding,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(binding);
            cancellationToken.ThrowIfCancellationRequested();
            return ValueTask.FromResult(_bindings.TryAdd(binding.ExternalIdentity, binding));
        }

        public ValueTask<ProfileExternalIdentityBinding?> FindByExternalIdentityAsync(
            ExternalIdentityReference externalIdentity,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(externalIdentity);
            cancellationToken.ThrowIfCancellationRequested();
            _bindings.TryGetValue(externalIdentity, out var binding);
            return ValueTask.FromResult(binding);
        }

        public ValueTask<IReadOnlyList<ProfileExternalIdentityBinding>> FindByProfileAsync(
            ProfileId profileId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IReadOnlyList<ProfileExternalIdentityBinding> bindings = _bindings.Values
                .Where(binding => binding.ProfileId == profileId)
                .ToArray();
            return ValueTask.FromResult(bindings);
        }

        public ValueTask<bool> RemoveAsync(
            ExternalIdentityReference externalIdentity,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(externalIdentity);
            cancellationToken.ThrowIfCancellationRequested();
            return ValueTask.FromResult(_bindings.TryRemove(externalIdentity, out _));
        }
    }
}
