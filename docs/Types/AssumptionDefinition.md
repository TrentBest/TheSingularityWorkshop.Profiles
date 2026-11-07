<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# AssumptionDefinition

## 01 — What

`AssumptionDefinition` is a sealed record that names a proposition an experience needs resolved. It carries a stable `Key`, human-readable `Description`, and `Func<Profile, bool>` resolver.

Source: [Assumptions.cs](../../Assumptions.cs).

## 02 — Why

The definition separates the proposition's identity and explanation from the code that evaluates it. A host can keep a catalog of experience requirements while supplying the profile data to an `IProfileAssumptionResolver`.

## 03 — How

The constructor rejects a null/blank key, null/blank description, and null resolver. The three values are exposed through get-only properties, and `Deconstruct` returns those constructor values. The resolver is executable application code; this type does not sandbox it, validate its meaning, or constrain which profile claims it reads.

The predicate receives the original `Profile`, not a redacted `ProfileRepresentation`. Callers must therefore place the resolver in a trusted boundary and must not interpret this mechanism as zero-knowledge evaluation or privacy-preserving proof.

## 04 — See it in a minute

```csharp
var ageRequirement = new AssumptionDefinition(
    "age-21-plus",
    "The profile represents someone aged 21 or older.",
    profile => profile.Claims.TryGetValue("age", out var claim)
        && claim.Value is int age
        && age >= 21);
```

The source tests validate constructor arguments and deconstruction, and exercise a definition through satisfied, not-satisfied, and unknown resolver outcomes in [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [Assumptions.cs](../../Assumptions.cs) for the complete definition and evaluation contracts.
- [IProfileAssumptionResolver](IProfileAssumptionResolver.md) for the resolver abstraction.
- [AssumptionResult](AssumptionResult.md) for the outcome model.
- [Privacy model](../PRIVACY.md) for the boundary around access to original profile data.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
