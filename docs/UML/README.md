<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles UML and type-documentation inventory

## 01 — What

This directory maps the public C# type system and the important interactions around it. UML pages are explanatory views; they do not replace source, XML API documentation, tests, or security enforcement.

## 02 — Why

A single aggregate diagram cannot answer every question. Type pages explain individual contracts; neighborhoods show users and dependencies; sequence diagrams explain collaboration over time; use cases explain the human or host goal. The inventory below makes missing views visible instead of implying that one diagram is complete.

## 03 — How: current coverage

**Inventory basis:** source file/type declarations visible in the `development` tree at the time this inventory was authored. This is a manual inventory, not generated or CI-enforced. Re-scan source before treating it as exhaustive.

### Existing artifact

| View | Status | Evidence / limitation |
|---|---|---|
| Aggregate domain UML | Exists | [ProfileUML.md](ProfileUML.md); hand-authored overview |
| Architecture/component view | Exists | [Architecture guide](../ARCHITECTURE.md) and source-informed SVG |
| Per-type pages | Planned | No complete per-type companion set yet |
| Per-type target-centered neighborhoods | Planned | Not generated |
| Per-type use cases | Planned | Human-authored work remains |
| Sequence diagrams | Planned | No complete workflow set |
| Activity/control-flow diagrams | Planned | No systematic branch/loop/exception inventory |
| State/lifecycle diagrams | Not applicable / limited | Current library has no central runtime state machine; revisit if lifecycle contracts emerge |
| Deployment/runtime topology | Not applicable | This is a domain library; deployment belongs to consuming hosts |
| Data model/data flow | Partial | Aggregate architecture and representation flow exist; no full per-type ownership/mutability catalog |
| Requirement/test traceability | Partial | Test files exist, but no exhaustive contract-to-test matrix |
| MicroBundle/manifest views | Not applicable | This repository does not define MicroBundles |

### Declared type inventory

| Source file | Declared types |
|---|---|
| `Assumptions.cs` | `AssumptionDefinition`, `AssumptionResultKind`, `AssumptionResult`, `IProfileAssumptionResolver`, `ProfileAssumptionResolver` |
| `Disclosure.cs` | `DisclosureScope`, `DisclosureRule` |
| `ExternalIdentityBinding.cs` | `ExternalIdentityReference`, `ProfileExternalIdentityBinding` |
| `Profile.cs` | `Profile` |
| `ProfileAccessLog.cs` | `ProfileAccessRecord`, `IProfileAccessRecorder` |
| `ProfileAttributeDefinition.cs` | `ProfileAttributeDefinition` |
| `ProfileClaim.cs` | `ProfileClaim` |
| `ProfileDataLicensePolicy.cs` | `ProfileDataLicensePolicy` |
| `ProfileEntityKind.cs` | `ProfileEntityKind` |
| `ProfileGroup.cs` | `ProfileGroup` |
| `ProfileId.cs` | `ProfileId` |
| `ProfileIdentityLink.cs` | `ProfileIdentityLink`, `ProfileIdentityLinkKind` |
| `ProfileIdentityLinkStore.cs` | `ProfileIdentityLinkStore` |
| `ProfilePublicDataReport.cs` | `ProfilePublicDataReport`, `ProfilePublicDataReporter` |
| `ProfileRelationship.cs` | `ProfileRelationship` |
| `ProfileRepresentation.cs` | `ProfileRepresentation` |

### UML page conventions

Each future per-type page should identify its exact target, purpose, responsibilities/non-goals, declaration kind, key public members, source-backed relationships, package references, examples/tests, limitations, and links to source.

Each companion `<TypeName>UML.md` should show verified consumers above, the focal type centered, dependencies below, relevant packages to the right, and a use-case section. Label scan scope and provenance. Do not invent consumers or infer use cases from AST/reflection alone.

Sequence diagrams should identify caller/callee source methods, inputs/outputs, important alternatives and failures, and complexity where meaningful. Distinguish static analysis from measured performance.

## 04 — See it in a minute

The existing [ProfileUML.md](ProfileUML.md) is the current aggregate map. It is a hand-authored conceptual/source-informed view, not a generated complete type graph. The [architecture SVG](../images/profiles-architecture.svg) illustrates the observer-specific representation flow and states its provenance.

## 05 — Choose your next step

- [API map](../API.md) for the public type overview.
- [Architecture](../ARCHITECTURE.md) for responsibility and dependency boundaries.
- [Privacy model](../PRIVACY.md) for disclosure semantics and limitations.
- [Contributor guide](../../AGENTS.md) for change and verification rules.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop avatar" width="200" /></p>
