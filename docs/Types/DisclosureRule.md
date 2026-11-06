<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `DisclosureRule`

## 01 — What

`DisclosureRule` is a sealed record defining the audience allowed to receive one profile attribute and an optional replacement value to use in an authorized representation.

Source: [Disclosure.cs](../../Disclosure.cs).

## 02 — Why

A profile can retain a canonical claim while presenting a narrower or substituted value to different observers. A rule makes the audience decision explicit and keeps observer IDs distinct from group IDs, preventing those two identifier categories from being accidentally interchanged.

The rule evaluates domain policy. It does not authenticate requesters or enforce security at a transport or storage boundary.

## 03 — How

### Constructor and members

```csharp
new DisclosureRule(
    string attributeKey,
    DisclosureScope scope,
    IReadOnlySet<ProfileId>? allowedObservers = null,
    IReadOnlySet<ProfileId>? allowedGroups = null,
    string? representationOverride = null)
```

- `AttributeKey` identifies the governed attribute; it must not be null, empty, or whitespace.
- `Scope` is validated against the defined `DisclosureScope` values.
- `AllowedObservers` is a defensive snapshot of observer IDs used by `Explicit`.
- `AllowedGroups` is a defensive snapshot of group IDs used by `Group`.
- `RepresentationOverride` is optional text substituted for every observer allowed by the rule.

The constructor rejects non-empty observer lists for scopes other than `Explicit`, non-empty group lists for scopes other than `Group`, and uninitialized IDs in either supplied set. The two audience collections are copied on input; each property access returns a new set snapshot.

### Evaluation

`Allows(requester, requesterGroups)` rejects an uninitialized requester, a null group set, or uninitialized group IDs. It then evaluates:

| Scope | Result |
|---|---|
| `Private` | `false` |
| `Public` | `true` |
| `Explicit` | requester is in `AllowedObservers` |
| `Group` | at least one requester group overlaps `AllowedGroups` |

### Integration with Profile

`Profile.SetDisclosureRule` stores a newly constructed copy of the supplied rule. During `Profile.RepresentTo`, a claim is included only when a matching rule exists and `Allows` returns true; when an override exists, that value is placed in the representation instead of the claim's canonical value. The display name is governed separately by the special `display-name` key.

### Limits and security boundary

- A rule without a matching claim does not create a claim or disclose a value.
- A `Group` rule trusts the group IDs supplied by the caller of `Allows`; it does not verify membership or the authority that issued those IDs.
- `RepresentationOverride` is a string, not a typed transformation or proof that the substituted value is safe.
- The rule does not authenticate callers, encrypt data, authorize access to the original `Profile` object, or replace host-side authorization.
- Disclosure controls the projection returned by `RepresentTo`; code that already holds the original mutable `Profile` can still read its claims.

## 04 — See it in a minute

```csharp
var emailRule = new DisclosureRule(
    "email",
    DisclosureScope.Explicit,
    allowedObservers: new HashSet<ProfileId> { trustedObserverId },
    representationOverride: "contact through the host");

bool mayRepresent = emailRule.Allows(
    trustedObserverId,
    new HashSet<ProfileId>());
```

## 05 — Choose your next step

- [DisclosureScope type reference](DisclosureScope.md)
- [ProfileClaim type reference](ProfileClaim.md)
- [Profile aggregate and observer projection](Profile.md)
- [Disclosure API](../API.md#disclosure)
- [Implementation](../../Disclosure.cs)
- [Disclosure tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
