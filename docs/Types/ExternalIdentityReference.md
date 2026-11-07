<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ExternalIdentityReference

## 01 — What

`ExternalIdentityReference` is a sealed record identifying an external account by an issuer/provider string and a provider-issued subject string.

**Declaration:** sealed record. Both properties are get-only.

## 02 — Why

External identity systems need a stable provider-qualified reference that can be associated with a domain profile without importing credentials, tokens, provider SDKs, or protocol behavior into Profiles.

The subject is not assumed to be an email address. A reference is data, not proof: constructing one does not authenticate a caller, verify an issuer, validate a signature, or prove control of the subject.

## 03 — How

The constructor rejects null, empty, or whitespace issuer and subject values. It stores the supplied strings as-is; this type does not normalize issuer URLs, canonicalize subjects, or perform provider-specific validation.

The issuer/subject pair is used by [ProfileExternalIdentityBinding](ProfileExternalIdentityBinding.md). Authentication and verification remain responsibilities of the integrating host.

Source: [ExternalIdentityBinding.cs](../../ExternalIdentityBinding.cs).

## 04 — See it in a minute

```csharp
var external = new ExternalIdentityReference(
    "https://identity.example.test",
    "subject-123");
```

The values must come from an appropriate integration flow. This constructor does not establish that they are trustworthy.

Relevant test: `ExternalIdentityRequiresIssuerAndSubject`.

## 05 — Choose your next step

- [Profile binding](ProfileExternalIdentityBinding.md)
- [Private profile links](ProfileIdentityLink.md)
- [Architecture](../ARCHITECTURE.md)


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
