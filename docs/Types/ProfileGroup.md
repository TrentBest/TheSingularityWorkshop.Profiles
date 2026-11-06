<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `ProfileGroup`

## 01 — What

`ProfileGroup` is a mutable, profile-domain group with a generated `ProfileId`, immutable name, and set of member profile IDs.

Source: [ProfileGroup.cs](../../ProfileGroup.cs).

## 02 — Why

Group membership can participate in `DisclosureScope.Group` evaluation. Keeping group IDs distinct from observer IDs makes the audience rule explicit while allowing the host to manage group membership through a small domain object.

## 03 — How

The constructor rejects a null, empty, or whitespace name, generates `Id` with `ProfileId.New()`, and retains `Name`.

- `Add`, `Remove`, and `Contains` reject uninitialized IDs and return the underlying set operation/result.
- `Members` returns a new `HashSet<ProfileId>` on every access. Mutating that returned set does not change the group's actual membership.
- Membership itself remains mutable through the group's methods.

A group does not authenticate members, establish who is entitled to add them, or prove the provenance of membership. The host is responsible for controlling who can mutate group membership and which group IDs are supplied to disclosure evaluation.

## 04 — See it in a minute

```csharp
var group = profile.DefineGroup("Project reviewers");
group.Add(reviewerProfileId);

bool isMember = group.Contains(reviewerProfileId);
var snapshot = group.Members; // independent copy
```

## 05 — Choose your next step

- [DisclosureScope](DisclosureScope.md)
- [DisclosureRule](DisclosureRule.md)
- [Profile aggregate](Profile.md)
- [Implementation](../../ProfileGroup.cs)
- [Group and disclosure tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
