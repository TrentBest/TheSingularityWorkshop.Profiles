<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `Profile`

## 01 — What

`Profile` is a sealed reference type and the central in-memory aggregate for one ecosystem entity. It owns a stable `ProfileId`, an entity kind, an optional display name, claims, disclosure rules, groups, relationships, exclusions, and avatar selections. It can produce an observer-specific `ProfileRepresentation`.

Source: [Profile.cs](../../Profile.cs).

## 02 — Why

A consuming application needs a reusable semantic object that separates an entity's information from the representation it chooses to disclose. Keeping this aggregate provider-neutral allows different hosts to choose persistence, authentication, transport, rendering, and jurisdiction policy without making those concerns dependencies of the domain model.

The aggregate is intentionally not a user account or a database abstraction.

## 03 — How

### Declaration and ownership

- **Kind:** `public sealed class`.
- **Construction:** `Profile(ProfileEntityKind kind, string? displayName = null)`; validates the enum and creates a new `ProfileId`.
- **Owned mutable state:** claim/rule/avatar/group dictionaries, relationship list, and exclusion set.
- **Read views:** `Claims`, `Groups`, and `Relationships` expose read-only wrappers over the aggregate's live collections; `ExcludedEntities` returns a new set snapshot. The wrappers prevent callers from changing collection structure through these properties, but do not make contained `ProfileClaim` or `ProfileGroup` objects deeply immutable.
- **Mutation:** fluent methods update the aggregate and generally return `this`; `DefineGroup` returns the existing or newly created group.

### Key public members

| Member | Purpose |
|---|---|
| `Id`, `Kind` | Stable identity and entity classification |
| `DisplayName` | Optional mutable name; disclosure is separately controlled |
| `Claims`, `Groups`, `Relationships` | Read-only collection views |
| `ExcludedEntities` | Snapshot of excluded observer IDs |
| `PublicAttributeKeys`, `IsDisplayNamePublic`, `HasPublicAvatar` | Exposure metadata; public attribute keys include only existing claims with a matching `Public` rule |
| `SetClaim`, `SetDisclosureRule` | Add/replace claim and audience rule |
| `DefineGroup`, `AddRelationship` | Add group and profile-owned relationship |
| `Exclude`, `RemoveExclusion` | Add/remove observer exclusion |
| `SetAvatar`, `SetPublicAvatar`, `SetGroupAvatar` | Configure avatar selection |
| `RepresentTo` | Produce observer-specific projection |

### Representation behavior

`RepresentTo(observer, observerGroups)` validates initialized IDs, combines host-supplied group IDs with memberships held by this Profile, then applies the following rules:

1. An excluded observer receives the same ProfileId, null display name, avatar `anonymous`, and an empty claims dictionary.
2. For a non-excluded observer, a claim is included only when it has a disclosure rule and that rule allows the observer/effective groups.
3. The display name has its own special `display-name` rule.
4. Avatar precedence is observer-specific, then a matching profile-defined group avatar, then the public/default avatar, then `anonymous`. When multiple matching profile groups have configured avatars, the first matching group encountered in the profile's group collection wins; do not treat group-avatar selection as a priority-ranking system.

For the exact audience predicates see [DisclosureRule](../API.md) and [Disclosure.cs](../../Disclosure.cs).

### Ownership, mutation, and security boundaries

- `Claims`, `Groups`, and `Relationships` are live read-only views: later mutations through the Profile API are reflected in them. `ExcludedEntities` is different: each access returns an independent snapshot.
- `DefineGroup` returns the existing group when the name is already defined; it does not replace that group's membership. Group membership is managed by the returned `ProfileGroup`.
- `AddRelationship` accepts only relationships whose `Subject` is this profile's `Id`; the relationship's other endpoint may refer to another profile.
- `PublicAttributeKeys` reports existing claims whose matching rule has `DisclosureScope.Public`; a public rule without a corresponding claim is not listed. `IsDisplayNamePublic` checks the separate `display-name` rule.
- Group IDs passed through `observerGroups` are trusted host context. Profiles does not authenticate or validate their provenance.
- The original Profile remains readable to any code that already holds it. A representation does not revoke access to the source object.
- The representation copies its claims dictionary structure, but arbitrary claim values are not deep-cloned. Prefer immutable claim payloads or treat them as immutable after publication.
- A disclosure decision is not encryption, authentication, host authorization enforcement, or a network security boundary.

## 04 — See it in a minute

```csharp
var language = ProfileAttributeDefinition.Create(
    "language", typeof(string), "Preferred language.");

var profile = new Profile(ProfileEntityKind.Individual, "Ari")
    .SetClaim(new ProfileClaim(language, "en-US"))
    .SetDisclosureRule(
        new DisclosureRule("language", DisclosureScope.Public));

var observer = ProfileId.New();
ProfileRepresentation representation = profile.RepresentTo(observer);
```

This example is source-shaped and should be built against the current project before being labelled runtime-verified. The repository's consumer examples are exercised by `ConsumerGuideExamplesTests.cs`.

## 05 — Choose your next step

- [Profile target-centered UML and use cases](../UML/ProfileTypeUML.md)
- [Privacy model](../PRIVACY.md)
- [Consuming guide](../CONSUMING.md)
- [Profile implementation](../../Profile.cs)
- [Profile tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs) — includes collection-view behavior, disclosure, group membership, exclusion, avatar precedence, and relationship ownership.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop avatar" width="200" /></p>
