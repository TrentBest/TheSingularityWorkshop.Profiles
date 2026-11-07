<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileIdentityLinkStore

## 01 — What

`ProfileIdentityLinkStore` is an in-memory collection for private `ProfileIdentityLink` values, intended for trusted identity infrastructure.

**Declaration:** sealed class. It provides `Add`, `Links`, and `IsLinked`.

## 02 — Why

The store keeps cross-profile identity associations separate from ordinary profile representations. This gives trusted infrastructure a focused place to manage and query the links without turning them into public profile claims.

It is not a persistence adapter, authentication provider, authorization engine, encryption boundary, legal-disclosure workflow, or proof of identity. The source does not establish thread-safety or durable storage.

## 03 — How

`Add` rejects null, ignores a duplicate record, and appends a new link. `Links` returns `List<T>.AsReadOnly()`: callers cannot mutate through that view, but it is a live wrapper over the store's list, not a frozen snapshot. `IsLinked` tests both orientations of the pair and does not filter by link kind.

The constructor of `ProfileIdentityLink` already rejects self-links; `Add` repeats that invariant check. The store does not independently verify ownership or relationship truth.

Source: [ProfileIdentityLinkStore.cs](../../ProfileIdentityLinkStore.cs). Related: [ProfileIdentityLink](ProfileIdentityLink.md).

## 04 — See it in a minute

```csharp
var store = new ProfileIdentityLinkStore();
store.Add(new ProfileIdentityLink(
    canonicalId,
    publisherId,
    ProfileIdentityLinkKind.Publisher));

bool associated = store.IsLinked(canonicalId, publisherId);
```

Keep the store behind trusted infrastructure. Do not expose its link list through public profile projections.

Relevant tests: `IdentityLinksRemainPrivateToTrustedInfrastructure`, `IdentityLinkStoreRejectsSelfLink`, and `IdentityLinkStoreDoesNotDuplicateLinks`.

## 05 — Choose your next step

- [Link value](ProfileIdentityLink.md)
- [Link categories](ProfileIdentityLinkKind.md)
- [External identity binding](ProfileExternalIdentityBinding.md)
- [Architecture](../ARCHITECTURE.md)


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
