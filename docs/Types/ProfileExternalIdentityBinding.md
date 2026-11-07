<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileExternalIdentityBinding

## 01 — What

`ProfileExternalIdentityBinding` is a sealed record associating an initialized `ProfileId` with an `ExternalIdentityReference`.

**Declaration:** sealed record. Its profile ID and external reference are get-only.

## 02 — Why

The binding gives an integration a provider-neutral mapping between a Profiles domain identity and an external account reference. It deliberately leaves authentication mechanics and credentials outside this library.

A mapping is not caller authentication, issuer verification, signature validation, proof of account ownership, authorization, organization membership, legal identity, or endorsement.

## 03 — How

The constructor rejects a default `ProfileId` and a null external reference. It does not independently verify that the external identity was authenticated or that the caller is permitted to bind it. The host integration must authenticate the principal, authorize mapping changes, and protect the binding in its chosen storage.

Source: [ExternalIdentityBinding.cs](../../ExternalIdentityBinding.cs). Related: [ExternalIdentityReference](ExternalIdentityReference.md).

## 04 — See it in a minute

```csharp
var external = new ExternalIdentityReference(issuer, subject);
var binding = new ProfileExternalIdentityBinding(profile.Id, external);
```

Only create this mapping after the host's trusted authentication and authorization flow has established that the association is permitted.

Relevant test: `ExternalIdentityBindingRequiresInitializedProfileId`.

## 05 — Choose your next step

- [External identity reference](ExternalIdentityReference.md)
- [Private identity-link store](ProfileIdentityLinkStore.md)
- [Privacy model](../PRIVACY.md)
- [Architecture](../ARCHITECTURE.md)


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
