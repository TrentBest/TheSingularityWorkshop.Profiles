<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileAssumptionResolver

## 01 — What

`ProfileAssumptionResolver` is the sealed default in-process implementation of `IProfileAssumptionResolver`.

Source: [Assumptions.cs](../../Assumptions.cs).

## 02 — Why

It provides a simple default mapping from a profile predicate's boolean result to the library's explicit three-state outcome.

## 03 — How

`Resolve` rejects null profile and assumption arguments, then invokes `assumption.Resolver(profile)` on the original profile:

- `true` produces `Satisfied` with proof label `profile-claim`.
- `false` produces `NotSatisfied` with no proof.
- `KeyNotFoundException` or `InvalidOperationException` produces `Unknown`.

Other exception types are not caught and will propagate to the caller. The implementation does not catch arbitrary exceptions, establish a trusted verifier, validate the resolver's logic, or create a cryptographic proof. Since the predicate receives the original profile, callers must treat it as trusted code with access to the profile's claims.

## 04 — See it in a minute

```csharp
IProfileAssumptionResolver resolver = new ProfileAssumptionResolver();
AssumptionResult result = resolver.Resolve(profile, ageRequirement);

Console.WriteLine($"{result.AssumptionKey}: {result.Kind}");
```

The tests `AssumptionCanBeSatisfied`, `AssumptionCanBeNotSatisfied`, and `UnknownAssumptionIsNotNotSatisfied` verify the three documented outcomes. Constructor validation for definitions is covered by `AssumptionDefinitionsRejectInvalidContractsAndRemainDeconstructable`. See [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [IProfileAssumptionResolver](IProfileAssumptionResolver.md) for the abstraction.
- [AssumptionDefinition](AssumptionDefinition.md) for the executable predicate.
- [AssumptionResultKind](AssumptionResultKind.md) for the outcome semantics.
- [Assumptions.cs](../../Assumptions.cs) for exact implementation.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
