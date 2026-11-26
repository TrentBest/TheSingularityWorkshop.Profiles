# IProfileExternalIdentityBindingStore

## Purpose

`IProfileExternalIdentityBindingStore` is the persistence seam for mapping an authenticated external subject to a stable Profiles `ProfileId`. It lets a host resolve an identity after its own authentication layer has established the caller's principal.

The interface is provider-neutral. It contains no HTTP, OAuth/OIDC, GitHub, database, token, credential, billing, or CiAi dependencies.

## Security boundary

The store is **not** an authenticator or authorization service. Constructing an `ExternalIdentityReference`, constructing a `ProfileExternalIdentityBinding`, or successfully reading a mapping does not authenticate the current caller.

The host must authenticate the external principal and authorize mapping creation, lookup disclosure, and removal. In particular, never accept an arbitrary caller-supplied issuer/subject pair as proof that the caller owns that identity.

## Persistence contract

Implementations must:

- persist mappings durably when used in production;
- atomically enforce uniqueness of an external issuer/subject pair across concurrent writers;
- never overwrite an existing profile mapping when `TryAddAsync` returns false;
- allow one profile to have multiple external identities;
- protect mapping data with appropriate access controls and operational safeguards;
- honor cancellation and propagate storage failures rather than converting failures into successful lookups.

`RemoveAsync` unlinks a mapping. The interface intentionally does not prescribe an audit schema. Hosts that need revocation history, provenance, review, or recovery must preserve those records in their own persistence boundary.

## Example composition

```csharp
// The host authenticates the principal and derives issuer/subject from
// the validated authentication result, not from untrusted request fields.
ExternalIdentityReference externalIdentity =
    new(validatedIssuer, validatedSubject);

ProfileExternalIdentityBinding? binding =
    await bindingStore.FindByExternalIdentityAsync(externalIdentity, cancellationToken);

if (binding is null)
{
    // Deny or begin an explicitly authorized account-linking flow.
    // Do not silently create a profile binding during ordinary sign-in.
}
else
{
    ProfileId stableProfileId = binding.ProfileId;
    // The host may now ask CiAi to verify entitlement for this licensee identity.
    // CiAi must independently validate the entitlement; Profiles grants no ADP rights.
}
```

The host must keep account-linking authorization, identity verification, entitlement verification, and ADP admission as separate decisions.

## Related types

- [ExternalIdentityReference](ExternalIdentityReference.md)
- [ProfileExternalIdentityBinding](ProfileExternalIdentityBinding.md)
- [Profiles architecture](../ARCHITECTURE.md)
