<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `ProfileRelationship`

## 01 — What

`ProfileRelationship` is an immutable sealed record describing a directed semantic relationship from one initialized profile ID (`Subject`) to another (`Target`) using an application-defined `RelationshipType`.

Source: [ProfileRelationship.cs](../../ProfileRelationship.cs).

## 02 — Why

Profiles need a way to express relationships without embedding a universal social graph vocabulary or requiring every relationship to be symmetric. A directed edge lets applications define their own terms and interpret direction explicitly.

## 03 — How

The constructor rejects default/uninitialized subject and target IDs and a null, empty, or whitespace relationship type. It stores the three values as get-only properties and supports deconstruction.

The record does not verify that either endpoint currently exists, load either profile, define reciprocal edges, normalize relationship names, or impose a controlled vocabulary. Those concerns belong to the consuming domain or host.

`Profile.AddRelationship` additionally requires the relationship's `Subject` to equal the owning profile's `Id`. That ownership check is performed by the aggregate, not by the relationship record's standalone constructor.

## 04 — See it in a minute

```csharp
var follows = new ProfileRelationship(
    subject: profile.Id,
    target: anotherProfileId,
    relationshipType: "follows");

profile.AddRelationship(follows);
```

## 05 — Choose your next step

- [Profile aggregate](Profile.md)
- [ProfileId](ProfileId.md)
- [Implementation](../../ProfileRelationship.cs)
- [Relationship tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
