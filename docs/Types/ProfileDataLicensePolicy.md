<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileDataLicensePolicy

## 1. What

`ProfileDataLicensePolicy` is a mutable sealed class describing an owner's explicit willingness to make selected profile attributes eligible for data licensing. It combines an enablement switch with an ordinal, case-sensitive attribute-key allow-list.

**Source:** [ProfileDataLicensePolicy.cs](../../ProfileDataLicensePolicy.cs)

## 2. Why

Public disclosure and commercial licensing are different decisions. A profile attribute being visible does not imply consent to sell, sublicense, or otherwise commercially exploit it. This policy gives a host a narrow domain-level signal that selected keys are eligible for a separate licensing workflow.

The policy does not itself create an offer, obtain transaction-specific authorization, process payment, implement revocation or expiry, or calculate a platform fee. Those responsibilities belong to the application or marketplace layer.

## 3. How

- `Enabled` controls whether any attribute can currently pass the policy check.
- `Allow(attributeKey)` adds a nonblank key to the allow-list.
- `Disallow(attributeKey)` removes a nonblank key and reports whether it was present.
- `CanLicense(attributeKey)` returns true only when licensing is enabled and the exact key is in the allow-list.
- `AttributeKeys` returns a defensive `HashSet<string>` snapshot exposed as `IReadOnlySet<string>`; changing the returned set does not mutate the policy.

Keys use `StringComparer.Ordinal`, so matching is exact and case-sensitive. All three key-taking methods reject null, empty, or whitespace-only values. The class is mutable and does not provide synchronization or persistence.

## 4. See it in a minute

```csharp
var policy = new ProfileDataLicensePolicy();
policy.Allow("display-name");

bool eligibleBeforeEnablement = policy.CanLicense("display-name"); // false
policy.Enabled = true;
bool eligibleAfterEnablement = policy.CanLicense("display-name"); // true
bool otherKeyEligible = policy.CanLicense("avatar"); // false
```

The result means only that the key passes this local policy. A host must still obtain any required user authorization and execute the actual licensing transaction.

## 5. Choose your next step

- Review [Profile](Profile.md) for the profile that owns claims and disclosure behavior.
- Review [ProfileRepresentation](ProfileRepresentation.md) for observer-specific disclosure; it is not a licensing contract.
- Review [API](../API.md) and [Privacy](../PRIVACY.md) for broader domain boundaries.
- Add or update tests when changing enablement, allow-list, or key-validation semantics.


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
