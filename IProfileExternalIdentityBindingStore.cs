namespace TheSingularityWorkshop.Profiles;

/// <summary>
/// Persistence boundary for provider-qualified external identity mappings.
/// </summary>
/// <remarks>
/// Implementations are supplied by trusted host infrastructure. <see cref="TryAddAsync"/>
/// must enforce uniqueness of an external identity atomically across concurrent callers:
/// one issuer/subject pair may resolve to at most one profile. A failed insert must not
/// overwrite an existing mapping. The store does not authenticate callers or authorize
/// mapping changes; the host must do both before calling it.
///
/// Implementations should persist mappings durably and protect them as sensitive identity
/// metadata. Removal unlinks a mapping; hosts that require revocation history, provenance,
/// or recovery must retain that audit information in their own persistence boundary.
/// </remarks>
public interface IProfileExternalIdentityBindingStore
{
    /// <summary>
    /// Atomically adds a mapping if the external identity is not already bound.
    /// </summary>
    /// <param name="binding">Mapping previously authorized by trusted host code.</param>
    /// <param name="cancellationToken">Cancellation request.</param>
    /// <returns>
    /// <see langword="true"/> when the mapping was added; otherwise <see langword="false"/>
    /// when the external identity already has a mapping.
    /// </returns>
    ValueTask<bool> TryAddAsync(
        ProfileExternalIdentityBinding binding,
        CancellationToken cancellationToken = default);

    /// <summary>Finds the profile mapped to an external identity, or null when absent.</summary>
    ValueTask<ProfileExternalIdentityBinding?> FindByExternalIdentityAsync(
        ExternalIdentityReference externalIdentity,
        CancellationToken cancellationToken = default);

    /// <summary>Finds all external identities mapped to a profile.</summary>
    ValueTask<IReadOnlyList<ProfileExternalIdentityBinding>> FindByProfileAsync(
        ProfileId profileId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes the mapping for an external identity. Audit and revocation history remain
    /// the responsibility of the host persistence layer.
    /// </summary>
    /// <returns><see langword="true"/> when a mapping was removed; otherwise false.</returns>
    ValueTask<bool> RemoveAsync(
        ExternalIdentityReference externalIdentity,
        CancellationToken cancellationToken = default);
}
