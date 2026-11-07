<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles UML and type-documentation inventory

## 01 — What

This directory maps the public C# type system and the important interactions around it. UML pages are explanatory views; they do not replace source, XML API documentation, tests, or security enforcement.

## 02 — Why

A single aggregate diagram cannot answer every question. Type pages explain individual contracts; neighborhoods show users and dependencies; sequence diagrams explain collaboration over time; use cases explain the human or host goal. The inventory below makes missing views visible instead of implying that one diagram is complete.

## 03 — How: current coverage

**Inventory basis:** manually inspected all 16 root-level C# implementation files in the `development` tree on 2026-11-07 and checked their top-level public declarations. The 25-type list below matches the declarations in those files. This is a source-reviewed manual inventory, not generated or CI-enforced; it does not enumerate nested/private types or external consumers. Source links point to the current `development` branch.

### Existing artifact

| View | Status | Evidence / limitation |
|---|---|---|
| Aggregate domain UML | Exists | [ProfileUML.md](ProfileUML.md); hand-authored overview |
| Architecture/component view | Exists | [Architecture guide](../ARCHITECTURE.md) and source-informed SVG |
| Per-type pages | Complete (25/25) | [Type reference index](../Types/README.md) links a focused page for every inventoried top-level public declaration; this does not imply complete UML or test traceability |
| Per-type target-centered neighborhoods | Partial | [Profile](ProfileTypeUML.md) and [ProfileClaim](ProfileClaimUML.md) are hand-authored/source-checked; remaining types are not yet covered |
| Per-type use cases | Partial | Profile use cases are documented in [ProfileTypeUML.md](ProfileTypeUML.md); claim workflows are documented in [ProfileClaimUML.md](ProfileClaimUML.md); remaining types are not yet covered |
| Sequence diagrams | Initial source-backed coverage | [InteractionSequences.md](InteractionSequences.md) documents representation and assumption-resolution flows; this is not yet a complete workflow set |
| Activity/control-flow diagrams | Planned | No systematic branch/loop/exception inventory |
| State/lifecycle diagrams | Not applicable / limited | Current library has no central runtime state machine; revisit if lifecycle contracts emerge |
| Deployment/runtime topology | Not applicable | This is a domain library; deployment belongs to consuming hosts |
| Data model/data flow | Partial | Aggregate architecture and representation flow exist; no full per-type ownership/mutability catalog |
| Requirement/test traceability | Partial | Test files exist, but no exhaustive contract-to-test matrix |
| MicroBundle/manifest views | Not applicable | This repository does not define MicroBundles |

### Declared type inventory

| Source file | Declared types |
|---|---|
| [`Assumptions.cs`](../../Assumptions.cs) | `AssumptionDefinition`, `AssumptionResultKind`, `AssumptionResult`, `IProfileAssumptionResolver`, `ProfileAssumptionResolver` |
| [`Disclosure.cs`](../../Disclosure.cs) | `DisclosureScope`, `DisclosureRule` |
| [`ExternalIdentityBinding.cs`](../../ExternalIdentityBinding.cs) | `ExternalIdentityReference`, `ProfileExternalIdentityBinding` |
| [`Profile.cs`](../../Profile.cs) | `Profile` |
| [`ProfileAccessLog.cs`](../../ProfileAccessLog.cs) | `ProfileAccessRecord`, `IProfileAccessRecorder` |
| [`ProfileAttributeDefinition.cs`](../../ProfileAttributeDefinition.cs) | `ProfileAttributeDefinition` |
| [`ProfileClaim.cs`](../../ProfileClaim.cs) | `ProfileClaim` |
| [`ProfileDataLicensePolicy.cs`](../../ProfileDataLicensePolicy.cs) | `ProfileDataLicensePolicy` |
| [`ProfileEntityKind.cs`](../../ProfileEntityKind.cs) | `ProfileEntityKind` |
| [`ProfileGroup.cs`](../../ProfileGroup.cs) | `ProfileGroup` |
| [`ProfileId.cs`](../../ProfileId.cs) | `ProfileId` |
| [`ProfileIdentityLink.cs`](../../ProfileIdentityLink.cs) | `ProfileIdentityLink`, `ProfileIdentityLinkKind` |
| [`ProfileIdentityLinkStore.cs`](../../ProfileIdentityLinkStore.cs) | `ProfileIdentityLinkStore` |
| [`ProfilePublicDataReport.cs`](../../ProfilePublicDataReport.cs) | `ProfilePublicDataReport`, `ProfilePublicDataReporter` |
| [`ProfileRelationship.cs`](../../ProfileRelationship.cs) | `ProfileRelationship` |
| [`ProfileRepresentation.cs`](../../ProfileRepresentation.cs) | `ProfileRepresentation` |

### UML page conventions

Each future per-type page should identify its exact target, purpose, responsibilities/non-goals, declaration kind, key public members, source-backed relationships, package references, examples/tests, limitations, and links to source.

Each companion `<TypeName>UML.md` should show verified consumers above, the focal type centered, dependencies below, relevant packages to the right, and a use-case section. Label scan scope and provenance. Do not invent consumers or infer use cases from AST/reflection alone.

Sequence diagrams should identify caller/callee source methods, inputs/outputs, important alternatives and failures, and complexity where meaningful. Distinguish static analysis from measured performance.

### Source-level contract observations

The public surface is intentionally concentrated in the root-level files. Several implementation details matter to documentation accuracy:

- `Profile`, `ProfileGroup`, and `ProfileDataLicensePolicy` are mutable domain objects; their collection views use read-only wrappers or defensive snapshots where documented, but this is not a deep-immutability guarantee for arbitrary claim values.
- `Profile.RepresentTo` creates an observer-specific projection. Exclusion returns an anonymous representation with no claims; ordinary disclosure rules govern claims and the special `display-name` key.
- `DisclosureRule` separates observer IDs from group IDs and validates scope-specific inputs. Group membership held by the profile itself participates in its projection logic.
- `ProfileAssumptionResolver` maps `KeyNotFoundException` and `InvalidOperationException` to `Unknown`; other exception types are not swallowed. The predicate receives the original `Profile`.
- `ProfileIdentityLinkStore` is an in-memory domain implementation, not a persistence adapter. Links are intended for trusted identity infrastructure and are not included in ordinary representations.
- `ExternalIdentityReference` and `ProfileExternalIdentityBinding` carry a mapping contract, not credentials or proof of authentication.
- `ProfilePublicDataReporter` reports configured public exposure metadata; it does not resolve every observer's eventual representation.

These observations are static source review, not a security audit or runtime verification.

## 04 — See it in a minute

The existing [ProfileUML.md](ProfileUML.md) is the current aggregate map. It is a hand-authored conceptual/source-informed view, not a generated complete type graph. The [architecture SVG](../images/profiles-architecture.svg) illustrates the observer-specific representation flow and states its provenance.

## 05 — Choose your next step

- [API map](../API.md) for the public type overview.
- [Architecture](../ARCHITECTURE.md) for responsibility and dependency boundaries.
- [Privacy model](../PRIVACY.md) for disclosure semantics and limitations.
- [Contributor guide](../../AGENTS.md) for change and verification rules.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
