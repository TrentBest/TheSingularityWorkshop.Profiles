<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileIdentityLink

## 01 — What

`ProfileIdentityLink` is a sealed record representing a private association between two distinct, initialized profiles. It stores a canonical profile ID, a linked profile ID, and a `ProfileIdentityLinkKind`.

**Declaration:** sealed record. The three values are get-only and the record supports deconstruction.

## 02 — Why

A person or organization may operate separate personas, publisher identities, or commercial identities while trusted infrastructure maintains their private relationship. Keeping this relationship outside ordinary profile representations prevents the mapping from becoming part of routine observer-facing disclosure.

This type does not authenticate either profile, prove common ownership, authorize access, or determine whether a legal disclosure demand is valid.

## 03 — How

The constructor rejects default IDs, self-links, and enum values not defined by `ProfileIdentityLinkKind`. The record itself is immutable after construction.

The canonical/linked labels express the stored direction and ownership convention; the store's `IsLinked` query treats the pair symmetrically. The `Kind` is a category, not evidence that the relationship has been independently verified.

Source: [ProfileIdentityLink.cs](../../ProfileIdentityLink.cs). Related: [ProfileIdentityLinkKind](ProfileIdentityLinkKind.md), [ProfileIdentityLinkStore](ProfileIdentityLinkStore.md).

## 04 — See it in a minute

```csharp
var link = new ProfileIdentityLink(
    canonicalProfileId,
    publisherProfileId,
    ProfileIdentityLinkKind.Publisher);
```

The IDs must already be initialized and must differ. The example creates a domain value only; it does not establish the truth of the association.

Relevant test: `IdentityLinksRejectUninitializedIdsAndUnknownKinds`.

## 05 — Choose your next step

- [Identity-link categories](ProfileIdentityLinkKind.md)
- [Trusted infrastructure store](ProfileIdentityLinkStore.md)
- [External identity mapping](ExternalIdentityReference.md)
- [Privacy model](../PRIVACY.md)


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
