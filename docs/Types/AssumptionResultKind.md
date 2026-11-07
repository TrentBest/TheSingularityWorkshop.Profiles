<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# AssumptionResultKind

## 01 — What

`AssumptionResultKind` is the outcome enum for an assumption evaluation. Its values are `Satisfied`, `NotSatisfied`, and `Unknown`.

Source: [Assumptions.cs](../../Assumptions.cs).

## 02 — Why

A boolean cannot distinguish a proposition that evaluated false from one that could not be evaluated because required information was unavailable. The three-state model preserves that distinction for consuming experiences.

## 03 — How

- `Satisfied`: the resolver evaluated the proposition as true.
- `NotSatisfied`: the resolver evaluated it as false.
- `Unknown`: the default resolver encountered `KeyNotFoundException` or `InvalidOperationException` while evaluating it.

Do not collapse `Unknown` into `NotSatisfied`. The enum itself does not define host policy for what an experience should do with any outcome.

## 04 — See it in a minute

```csharp
switch (result.Kind)
{
    case AssumptionResultKind.Satisfied:
        // The proposition evaluated true.
        break;
    case AssumptionResultKind.NotSatisfied:
        // The proposition evaluated false.
        break;
    case AssumptionResultKind.Unknown:
        // Evidence was insufficient or evaluation could not complete.
        break;
}
```

The tests `AssumptionCanBeSatisfied`, `AssumptionCanBeNotSatisfied`, and `UnknownAssumptionIsNotNotSatisfied` cover the three outcomes in [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [AssumptionResult](AssumptionResult.md) for the result payload.
- [ProfileAssumptionResolver](ProfileAssumptionResolver.md) for the default mapping.
- [Assumptions.cs](../../Assumptions.cs) for source.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
