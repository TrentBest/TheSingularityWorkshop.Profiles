<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `ProfileAttributeDefinition`

## 01 — What

`ProfileAttributeDefinition` is an immutable sealed record describing a profile attribute by key, CLR value type, and optional human-readable description.

Source: [ProfileAttributeDefinition.cs](../../ProfileAttributeDefinition.cs).

## 02 — Why

A definition separates an attribute's meaning and expected runtime type from the value stored in a `ProfileClaim`. It gives claim construction a consistent type check without prescribing a global schema registry or serialization format.

## 03 — How

The constructor rejects a null, empty, or whitespace key and a null `Type`. It stores `Key`, `ValueType`, and optional `Description`. `Create(key, valueType, description)` is a factory for the same constructor contract. The record also supports deconstruction into those three values.

A `ProfileClaim` checks its supplied value with `ValueType.IsInstanceOfType`. This is CLR assignability validation, not schema validation, normalization, serialization compatibility, or semantic validation. Key uniqueness/canonicalization beyond the exact key used by the profile's claim dictionary is not supplied by this type.

## 04 — See it in a minute

```csharp
var yearsExperience = ProfileAttributeDefinition.Create(
    "years-experience",
    typeof(int),
    "Completed years of professional experience");

var claim = new ProfileClaim(yearsExperience, 12);
```

## 05 — Choose your next step

- [ProfileClaim](ProfileClaim.md)
- [Profile aggregate](Profile.md)
- [Implementation](../../ProfileAttributeDefinition.cs)
- [Definition and claim tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
