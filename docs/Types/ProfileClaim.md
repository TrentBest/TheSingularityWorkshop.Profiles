<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `ProfileClaim`

## 01 — What

`ProfileClaim` is a sealed reference type holding one value together with its `ProfileAttributeDefinition`, optional verification timestamp, and optional provenance string.

Source: [ProfileClaim.cs](../../ProfileClaim.cs).

## 02 — Why

The claim packages a value with the contract needed to interpret it and optional context about when and by whom it was verified. A claim is data with metadata; it is not, by itself, an assertion that the value is accurate or currently trusted.

## 03 — How

The constructor requires a non-null definition and non-null value. It rejects values for which `definition.ValueType.IsInstanceOfType(value)` is false. It then retains `Definition`, `Value`, `VerifiedAt`, and `Provenance`. `IsVerified` is true exactly when `VerifiedAt` has a value.

### Trust and ownership boundaries

- `IsVerified` means a timestamp was supplied; it does not validate the verifier, provenance, signature, freshness, or truth of the value.
- `Provenance` is descriptive text, not a cryptographic attestation or trusted authority object.
- The value is retained by reference and is not deep-cloned. Prefer immutable values or treat mutable values as immutable while the claim is in use.
- The type check enforces CLR assignability only; domain-specific validation belongs to the application or a higher-level contract.
- Consumers must not expose raw claim values without applying the relevant disclosure policy.

## 04 — See it in a minute

```csharp
var definition = ProfileAttributeDefinition.Create("role", typeof(string));
var claim = new ProfileClaim(
    definition,
    "architect",
    verifiedAt: DateTimeOffset.UtcNow,
    provenance: "internal-review");

if (claim.IsVerified)
    Console.WriteLine(claim.Value);
```

## 05 — Choose your next step

- [ProfileAttributeDefinition](ProfileAttributeDefinition.md)
- [DisclosureRule](DisclosureRule.md)
- [Profile aggregate](Profile.md)
- [Implementation](../../ProfileClaim.cs)
- [Claim tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
