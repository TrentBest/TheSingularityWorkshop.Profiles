<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles documentation audit

> **Status:** Working inventory of the `development` branch, inspected 2026-11-06. This is a documentation review, not a source-generated inventory or a CI verification report.

## 01 — What

This audit records the current documentation surface, identifies concrete consistency defects, and separates existing coverage from work that remains. The source code, tests, package metadata, and current workflow runs remain authoritative for implementation and verification.

## 02 — Why

Profiles has a substantial documentation foundation. The next improvement should not be another broad introductory document: it should make the existing material consistent, trace public contracts to source and tests, and ensure consumers can navigate from the README to the exact guidance they need.

## 03 — How: current inventory

| Area | Existing authority | Current assessment | Next improvement |
|---|---|---|---|
| Repository front door | `README.md` | Strong domain explanation, example, package boundaries, and navigation | Correct moniker source; move Sith badge into the badge row; remove personal-avatar footer; retain canonical Workshop footer |
| Contributor onboarding | `AGENTS.md` | Clear mission, ownership, safety, workflow, and evidence rules | Keep aligned with the shared Workshop standard and this audit |
| LLM onboarding | `ProfilesLLM.md` | Strong source map and important behavioral/security caveats | Add links to type-level pages as those pages become authoritative |
| Documentation navigation | `docs/DOCUMENTATION_INDEX.md` | Useful reader paths across consumer, domain, contributor, and release topics | Link this audit and distinguish authoritative guides from inventories |
| Consumer guide | `docs/CONSUMING.md` | Covers installation, profiles, claims, disclosure, groups, assumptions, identity, licensing, access records, and host responsibilities | Verify every example against the current API and executable example tests |
| Task recipes | `docs/HOW_TO.md` | Covers common disclosure, identity, group, avatar, exclusion, assumption, licensing, exposure, and access-record tasks | Cross-link recipes to the relevant type pages and tests |
| Domain definition | `docs/DOMAIN_DEFINITION.md` | Strong vocabulary and responsibility boundaries | Add source/test traceability for each implemented contract |
| Architecture | `docs/ARCHITECTURE.md` and `docs/images/profiles-architecture.svg` | Good package boundaries and observer-projection explanation; SVG is explicitly hand-authored/source-informed | Keep provenance honest; later generate semantic diagrams from a normalized source model |
| Privacy | `docs/PRIVACY.md` | Explains ownership, minimum disclosure, exclusion, identity/persona, licensing, and enforcement limits | Add a compact behavior-to-test map for negative and boundary cases |
| Theory | `docs/THEORY.md` | Broad conceptual coverage across identity, micro-data, uncertainty, sovereignty, disclosure, licensing, groups, and mutability | Split into navigable chapters only when each chapter adds distinct depth and source-backed examples |
| API map | `docs/API.md` | Broad public-type overview | Make each declared public type traceable to a focused type page, XML docs, and tests |
| UML inventory | `docs/UML/README.md`, `docs/UML/ProfileUML.md` | Aggregate and Profile-centered material exist; inventory already lists declared types | Complete remaining type pages and neighborhoods; add selected sequence/control-flow diagrams and contract/test traceability |
| Gallery | `Gallery.md` | Explains the current diagram, examples, provenance, and future living-documentation path | Keep it a visual tour rather than duplicating the full theory or API guide |
| Package/release guidance | `docs/PUBLISHING.md`, `.github/workflows/build.yml` | Build/package validation and multiple publish gates are documented | Preserve the gates; refresh feed/version/run evidence before any release |
| Development checkpoint | `docs/PAUSE_POINT.md` | Captures current known gaps and guardrails | Update when material work lands; never treat this hand-maintained page as live CI evidence |
| Branch policy | `.github/workflows/sith-policy.yml`, `assets/sith-policy.svg` | Enforces the two-branch target | Recheck after branch-changing operations; do not add branches for documentation work |

## 04 — Findings and ordered work

### Immediate consistency defects

1. The README moniker currently points to the Renderer repository, while the repository's other current documentation uses the Visualize moniker. Standardize on the canonical Workshop moniker source used by the shared documentation standard.
2. The README Sith badge is separated below the architecture image rather than sitting with the other repository badges.
3. The README contains a personal GitHub avatar image before the footer. Remove that personal-avatar treatment; retain the canonical Workshop footer image:
   `https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png`
4. Keep one clear footer convention. Do not substitute Avatar.jpg, a personal avatar, or an SVG moniker for the canonical footer PNG.
5. Several focused guides are intentionally concise and some lack the shared moniker/footer treatment. Align them as they are substantively edited rather than performing risky, blind mass replacements.

### Domain/type documentation

The current UML inventory names these declared types:

| Source | Declared types |
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

A direct inspection of all 16 root-level C# implementation files on development confirmed these 24 top-level public declarations. This is a manual source scan, not a Roslyn-generated inventory or CI drift check. The scan does not enumerate nested/private declarations or all external consumers. The focused ProfileAttributeDefinition and ProfileClaim pages now link their contracts to source and tests; continue checking each remaining type neighborhood directly rather than treating this inventory as a generated call graph.

### Existing coverage versus missing coverage

- **Exists:** README, consumer guide, task recipes, theory, architecture, domain definition, privacy, API map, publishing guide, Gallery, contributor guide, LLM onboarding, documentation index, aggregate UML, and a Profile-centered UML/use-case page.
- **Partial:** per-type documentation, per-type target-centered UML/use cases, source-to-test traceability, data ownership/mutability catalog, and architecture diagram coverage.
- **Not yet systematic:** sequence diagrams for key interactions and activity/control-flow diagrams for meaningful alternatives, failures, and exceptions.
- **Not appropriate by default:** deployment topology and MicroBundle/manifest diagrams; Profiles is a domain library and does not own host deployment or MicroBundles.

## 05 — Next execution sequence

1. Fix README branding, badge placement, and footer without changing domain semantics.
2. Independently scan current source declarations and public members; compare the result with `docs/UML/README.md` and `docs/API.md`.
3. Create focused pages in batches by domain neighborhood (identity, claims/disclosure, representation, groups/relationships, assumptions, identity links, licensing/exposure, access records).
4. For each page, identify source declarations, public members, verified relationships, relevant tests, consumer examples, limitations, and provenance.
5. Add sequence diagrams only for interactions whose control flow is useful and source-verifiable.
6. Strengthen CI to validate internal documentation links, required branding, public-type inventory drift, and executable examples where practical.
7. Run the actual build/test workflow and report the exact revision and results. Do not claim green CI based on file presence or an unrun command.

## Guardrails

- Work on `development`; preserve exactly `master` and `development`.
- Keep Profiles independently consumable and provider-neutral.
- A representation is not authentication, authorization, encryption, or complete host security.
- Identity bindings are not caller authentication; assumptions are not zero-knowledge proofs; licensing policy is not a transaction.
- Do not weaken existing verification or NuGet publication gates.
- No merge, branch deletion, release, deployment, or NuGet publication is authorized by this audit.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
