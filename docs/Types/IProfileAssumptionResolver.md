<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# IProfileAssumptionResolver

## 01 — What

`IProfileAssumptionResolver` is the public interface for resolving an `AssumptionDefinition` against a `Profile`. Its single method is `Resolve(Profile profile, AssumptionDefinition assumption)`, returning an `AssumptionResult`.

Source: [Assumptions.cs](../../Assumptions.cs).

## 02 — Why

The interface lets a consuming host depend on the resolution contract rather than the default in-process implementation. It leaves room for a host-specific resolver while keeping the domain result shape stable.

## 03 — How

The interface defines the method contract only. The current default implementation is [`ProfileAssumptionResolver`](ProfileAssumptionResolver.md). The interface does not prescribe remote execution, proof verification, caching, persistence, or exception mapping for alternative implementations.

The default implementation invokes the supplied predicate on the original profile. This is a trusted-code extension point, not a privacy-preserving query interface. A host that supplies another implementation must define and document its own trust, failure, and evidence semantics.

## 04 — See it in a minute

```csharp
IProfileAssumptionResolver resolver = new ProfileAssumptionResolver();
AssumptionResult result = resolver.Resolve(profile, ageRequirement);
```

The existing integration tests exercise the default implementation through the interface-compatible contract. See [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [ProfileAssumptionResolver](ProfileAssumptionResolver.md) for the default implementation.
- [AssumptionDefinition](AssumptionDefinition.md) for the predicate contract.
- [AssumptionResult](AssumptionResult.md) for returned outcomes.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
