<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles — LLM onboarding

This is the entry point for an AI agent or coding assistant joining this repository. It is deliberately self-contained enough to establish the mission, boundaries, working rules, and first reading path. The source code and tests remain authoritative for implemented behavior.

## 01 — What this repository is

**TheSingularityWorkshop.Profiles** is a provider-neutral .NET domain package that models an entity's profile, typed claims, disclosure rules, groups, relationships, observer-specific representations, assumption outcomes, identity-link contracts, public-exposure metadata, access-record contracts, and opt-in data-licensing policy.

A Profile is an in-process domain object, not a database row, login account, authentication provider, UI view, or complete security boundary.

## 02 — Why the boundary matters

Applications frequently mix canonical identity, public persona, private attributes, audience rules, authentication, and presentation into one application-specific record. Profiles separates reusable domain semantics from infrastructure so different hosts can make their own storage, identity, verification, transport, and presentation choices.

The central distinction is:

- **Identity:** which entity the Profile represents.
- **Claim:** a typed piece of information associated with that entity.
- **Disclosure:** whether a given observer context may receive a claim representation.
- **Representation:** the observer-specific projection produced by the domain object.
- **Verification:** an external or application-defined standard for establishing a proposition; not implied by disclosure.
- **Licensing:** an opt-in policy flag and key allow-list; not a sale or transaction.

## 03 — How the implementation is shaped

Primary source areas:

| Area | Source | Responsibility |
|---|---|---|
| Profile aggregate and representation | `Profile.cs` | Holds claims, rules, groups, relationships, exclusions, avatars; creates observer projections |
| Disclosure contract | `Disclosure.cs` | Public, private, explicit-observer, and group-based decisions |
| Claim metadata/value | `ProfileClaim.cs`, `ProfileAttributeDefinition.cs` | Typed claim definition and value |
| Representation | `ProfileRepresentation.cs` | Read-only copied claims dictionary and observer-facing fields |
| Assumptions | `Assumptions.cs` | Satisfied / NotSatisfied / Unknown outcomes |
| Identity binding | `ExternalIdentityBinding.cs`, `ProfileIdentityLink.cs`, `ProfileIdentityLinkStore.cs` | Provider-qualified external references and private profile links |
| Groups and relationships | `ProfileGroup.cs`, `ProfileRelationship.cs` | Membership and semantic relationships |
| Licensing and exposure | `ProfileDataLicensePolicy.cs`, `ProfilePublicDataReport.cs` | Opt-in license policy and public exposure metadata |
| Access records | `ProfileAccessLog.cs` | Minimal record/recorder contracts |

### Important behavior to preserve

- A claim without a matching disclosure rule is omitted from the representation.
- `Private` denies, `Public` permits, `Explicit` checks observer IDs, and `Group` checks overlap with effective group IDs.
- Group IDs supplied to `RepresentTo` are host-supplied context. Profiles does not authenticate the caller or validate the trustworthiness of those memberships.
- The special `display-name` rule controls display-name disclosure independently of ordinary claim rules.
- Avatar resolution prefers observer-specific, then matching group, then public/default, then `anonymous`.
- An excluded observer receives an anonymous projection with the same ProfileId, null display name, and no claims.
- `ProfileRepresentation` copies and protects the claims dictionary structure; it does not deep-clone arbitrary claim values.
- The default assumption resolver executes a delegate against the original Profile. A resolver can inspect raw claims; it is not a zero-knowledge proof system.
- External identity binding contracts do not authenticate an incoming caller.
- A licensing policy does not create a marketplace, buyer, price, payment, or legal authorization.

## 04 — See it in a minute

A minimal source-shaped flow:

```csharp
var definition = ProfileAttributeDefinition.Create(
    "language", typeof(string), "Preferred language.");

var profile = new Profile(ProfileEntityKind.Individual, "Ari")
    .SetClaim(new ProfileClaim(definition, "en-US"))
    .SetDisclosureRule(
        new DisclosureRule("language", DisclosureScope.Public));

var observer = ProfileId.New();
ProfileRepresentation view = profile.RepresentTo(observer);
```

This demonstrates the domain projection only. It does not demonstrate authentication, network access control, persistence, or safe handling of mutable claim payloads.

## 05 — How to work here

1. Read [AGENTS.md](AGENTS.md) and the [documentation index](docs/DOCUMENTATION_INDEX.md).
2. Read the domain/architecture/privacy docs before proposing a new responsibility.
3. Inspect the exact source and tests for any behavior you describe or change.
4. Add or update tests for normal, boundary, and negative cases.
5. Update the relevant consumer guide and type/UML inventory when public behavior changes.
6. Run build and tests; report exact revision, commands, and results.
7. Commit focused changes to `development`.

### Tests as executable evidence

- `ProfileTests.cs` exercises Profile behavior, validation, disclosure, representation, identity, and assumptions.
- `ProfileDataLicensePolicyTests.cs` exercises licensing-policy invariants.
- `ConsumerGuideExamplesTests.cs` compiles/runs consumer scenarios from the guide.

Do not infer full test coverage from these filenames. Inspect the tests relevant to the behavior under change.

## Architectural non-goals

Do not add database persistence, account authentication, cryptographic identity proof, external verification, payment, marketplace, legal compliance, rendering, transport, or host authorization enforcement to this domain package by implication. Such work requires an explicit owner decision and a clear package boundary.

## Repository operating rules

- Use `development` for active work; `master` is the released baseline.
- Keep only `master` and `development`.
- Never publish NuGet, create a release, or dispatch a publish-enabled workflow unless the owner explicitly authorizes that release.
- Do not merge or delete branches without explicit authorization.
- Do not report an action as complete until the tool confirms it and the result has been checked.
- When onboarding another LLM, direct it to this file and AGENTS.md first; then give it a narrow, explicit workstream and identify shared files it must not concurrently edit.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop avatar" width="200" /></p>
