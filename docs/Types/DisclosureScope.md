<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `DisclosureScope`

## 01 — What

`DisclosureScope` is the public enum that names the four audience modes understood by a `DisclosureRule`: `Private`, `Public`, `Group`, and `Explicit`.

Source: [Disclosure.cs](../../Disclosure.cs).

## 02 — Why

A claim's presence in a profile is separate from whether it belongs in a particular observer's representation. This enum gives the rule a compact, explicit audience category while keeping the actual observer and group identifiers in separate, strongly typed sets.

It is a domain-level disclosure vocabulary, not an authorization framework or a complete security boundary.

## 03 — How

| Value | Meaning in `DisclosureRule.Allows` |
|---|---|
| `Private` | Denies every requester |
| `Public` | Allows every initialized requester |
| `Group` | Allows requesters whose group set overlaps the rule's allowed group IDs |
| `Explicit` | Allows only requester IDs in the rule's allowed observer set |

The enum is validated by `DisclosureRule` using `Enum.IsDefined`. Values are implicitly numbered by declaration order; do not treat those ordinals as a stable persistence or wire contract. Use symbolic values or an explicit versioned mapping when serializing.

### Boundaries

- `Public` means the rule allows a representation to include the governed value; it does not publish data by itself.
- `Group` depends on the group IDs supplied to the rule evaluation. In `Profile.RepresentTo`, the host may supply trusted external group context and the profile also contributes its own group memberships.
- `Explicit` is an observer-ID allow-list, not a group allow-list.
- A scope does not authenticate an observer, establish group membership provenance, encrypt data, or enforce host/API access control.

## 04 — See it in a minute

```csharp
var publicRule = new DisclosureRule("language", DisclosureScope.Public);
var privateRule = new DisclosureRule("legal-name", DisclosureScope.Private);
var groupRule = new DisclosureRule(
    "project-role",
    DisclosureScope.Group,
    allowedGroups: new HashSet<ProfileId> { projectMembersGroupId });
var explicitRule = new DisclosureRule(
    "email",
    DisclosureScope.Explicit,
    allowedObservers: new HashSet<ProfileId> { trustedObserverId });
```

## 05 — Choose your next step

- [DisclosureRule type reference](DisclosureRule.md)
- [Profile aggregate and representation](Profile.md)
- [Disclosure API](../API.md#disclosure)
- [Implementation](../../Disclosure.cs)
- [Disclosure and profile tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
