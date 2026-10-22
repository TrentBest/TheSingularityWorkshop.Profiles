using TheSingularityWorkshop.Profiles;
using Xunit;

namespace TheSingularityWorkshop.Profiles.Tests;

/// <summary>
/// Compile-checked consumer-guide examples. These tests keep the main onboarding path
/// aligned with the public API without turning the guide into a second test suite.
/// </summary>
public sealed class ConsumerGuideExamplesTests
{
    [Fact]
    public void ClaimDisclosureAndRepresentationExampleCompilesAndRuns()
    {
        var player = new Profile(ProfileEntityKind.Individual, "Ari");
        var language = ProfileAttributeDefinition.Create(
            "language",
            typeof(string),
            "Preferred language.");

        player.SetClaim(new ProfileClaim(language, "en-US"));
        player.SetDisclosureRule(
            new DisclosureRule("language", DisclosureScope.Public));

        var observerId = ProfileId.New();
        var representation = player.RepresentTo(observerId);

        Assert.Equal("en-US", representation.Claims["language"]);
    }

    [Fact]
    public void GroupMembershipAndAvatarExampleCompilesAndRuns()
    {
        var player = new Profile(ProfileEntityKind.Individual, "Ari");
        var friends = player.DefineGroup("Friends");
        var friendId = ProfileId.New();

        Assert.True(friends.Add(friendId));
        player.SetGroupAvatar("Friends", "cheshire-cat");

        var representation = player.RepresentTo(friendId);

        Assert.Equal("cheshire-cat", representation.Avatar);
    }

    [Fact]
    public void AssumptionAndLicensingExamplesCompileAndRun()
    {
        var player = new Profile(ProfileEntityKind.Individual, "Ari");
        var age = ProfileAttributeDefinition.Create("age", typeof(int));
        player.SetClaim(new ProfileClaim(age, 25));

        var adult = new AssumptionDefinition(
            "age-21-plus",
            "The profile represents someone aged 21 or older.",
            p => (int)p.Claims["age"].Value >= 21);

        var result = new ProfileAssumptionResolver().Resolve(player, adult);
        var policy = new ProfileDataLicensePolicy { Enabled = true };
        policy.Allow("age");

        Assert.Equal(AssumptionResultKind.Satisfied, result.Kind);
        Assert.True(policy.CanLicense("age"));
    }

    [Fact]
    public void PrivateIdentityLinkExampleCompilesAndRuns()
    {
        var canonical = new Profile(ProfileEntityKind.Individual, "Ari");
        var publisher = new Profile(ProfileEntityKind.Individual, "A. Best");
        var store = new ProfileIdentityLinkStore();

        store.Add(new ProfileIdentityLink(
            canonical.Id,
            publisher.Id,
            ProfileIdentityLinkKind.Publisher));

        Assert.True(store.IsLinked(canonical.Id, publisher.Id));
    }
}
