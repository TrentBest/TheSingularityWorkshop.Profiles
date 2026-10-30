<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles development pause point



## Current verified snapshot

- Repository: `TrentBest/TheSingularityWorkshop.Profiles`
- Working branch: `development`
- Intended branches: `master` and `development` only
- Package: `TheSingularityWorkshop.Profiles`
- Project target: `.NET 8`
- Package version in project metadata: `0.1.0-alpha.1`
- NuGet publication: **not authorized by this document**; owner authorization is required for every release.

This page is a hand-maintained checkpoint, not a live status feed. Refresh commit IDs, workflow runs, package-feed status, and test evidence before using it for a release decision.

## Product boundary

Profiles owns reusable entity/profile semantics, typed claims, disclosure rules, groups, relationships, observer representations, assumption outcomes, identity-link contracts, exposure metadata, access-record contracts, and opt-in data-license policy.

The consuming host owns persistence, authentication, transport, rendering, verification authority, transaction execution, jurisdiction decisions, and enforcement.

## Existing verification assets

- `tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs`
- `tests/TheSingularityWorkshop.Profiles.Tests/ProfileDataLicensePolicyTests.cs`
- `tests/TheSingularityWorkshop.Profiles.Tests/ConsumerGuideExamplesTests.cs`

The existence of these files is not evidence that the current revision builds or passes. Run the workflow or local commands and record the actual result before claiming verification.

## Current documentation assets

- README and Gallery
- Consumer guide and task recipes
- Architecture, domain definition, privacy, and theory
- API map and publishing guidance
- One aggregate UML page: `docs/UML/ProfileUML.md`

The per-type documentation family, per-type UML/use-case pages, sequence/control-flow coverage, and automated documentation inventory are not yet complete. See [UML inventory](UML/README.md).

## Next recommended work

1. Make CI publication impossible without an explicit owner-controlled release authorization, not merely a manually supplied boolean input.
2. Add a source-derived per-type inventory and focused type/UML/use-case pages.
3. Expand theory into modular, source-mapped chapters with evidence and counterexamples.
4. Validate README badges, internal links, package metadata, examples, and image links.
5. Run build/tests and record fresh evidence.
6. Align the remaining Markdown files to the canonical moniker/footer convention as they are substantively edited.

## Safety and release guardrails

No package publication, release creation, branch merge, or branch deletion is authorized by this checkpoint. Preserve the two-branch policy and work on `development`.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop avatar" width="200" /></p>
