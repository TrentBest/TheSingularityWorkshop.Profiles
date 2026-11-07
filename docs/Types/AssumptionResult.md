<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# AssumptionResult

## 01 — What

`AssumptionResult` is a sealed record containing an `AssumptionKey`, an `AssumptionResultKind`, and an optional `Proof` string. Its computed `IsSatisfied` property is true only when `Kind == Satisfied`.

Source: [Assumptions.cs](../../Assumptions.cs).

## 02 — Why

The result carries the minimum outcome information needed by a consuming experience without returning unrelated profile claims or values.

## 03 — How

The positional record exposes its constructor values. `IsSatisfied` is a convenience boolean; it is false for both `NotSatisfied` and `Unknown`, so consumers that need to distinguish those outcomes must inspect `Kind`.

The default resolver currently supplies the literal proof label `profile-claim` for a satisfied result and no proof for the other outcomes. This is descriptive provenance, not a cryptographic proof, verifier signature, or independently validated evidence artifact.

## 04 — See it in a minute

```csharp
if (result.Kind == AssumptionResultKind.Unknown)
{
    // Keep uncertainty distinct from a failed proposition.
}
else if (result.IsSatisfied)
{
    // The proposition evaluated true.
}
```

The source tests assert the outcome kind, `IsSatisfied`, and satisfied proof label for the default resolver. See [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [AssumptionResultKind](AssumptionResultKind.md) for the three-state outcome.
- [ProfileAssumptionResolver](ProfileAssumptionResolver.md) for result construction.
- [Assumptions.cs](../../Assumptions.cs) for source.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
