<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Contributor guide — Profiles

This file is the repository-level operating guide for humans and coding agents. Read it before changing source, tests, workflows, or documentation.

## Mission and ownership

**TheSingularityWorkshop.Profiles** is a provider-neutral .NET domain library for entity profiles, claims, relationships, audience disclosure, observer-specific representations, assumption outcomes, identity-link contracts, exposure metadata, access-record contracts, and opt-in data-licensing policy.

Keep the core independent of application infrastructure. The consuming host owns persistence, authentication, transport, rendering, verification authority, transaction execution, jurisdiction-specific decisions, and enforcement.

## Required reading

1. [README](README.md) — purpose, first example, and package boundaries.
2. [Domain definition](docs/DOMAIN_DEFINITION.md) — vocabulary and domain contracts.
3. [Architecture](docs/ARCHITECTURE.md) — responsibility ownership and dependency direction.
4. [Privacy model](docs/PRIVACY.md) — disclosure semantics and security limitations.
5. [Consuming guide](docs/CONSUMING.md) and [How-to guide](docs/HOW_TO.md) — consumer workflows.
6. [API map](docs/API.md) — public type inventory.
7. [ProfilesLLM.md](ProfilesLLM.md) — AI-specific repository onboarding and work protocol.
8. [Pause point](docs/PAUSE_POINT.md) — current verified state and next work.

## Non-negotiable engineering constraints

- Preserve the package's provider-neutral, application-independent domain boundary.
- Do not add dependencies on UI frameworks, identity providers, databases, transports, or application hosts without an explicit architectural decision.
- Do not treat disclosure as authentication, authorization enforcement, encryption, or a complete security boundary.
- Do not treat verification timestamps/proofs, identity bindings, or licensing flags as proof of external authority or completed transactions.
- Preserve the distinction between `Unknown` and `NotSatisfied`.
- Do not expose private identity links through ordinary observer representations.
- Keep tests aligned with public contracts and important negative/security-boundary cases.
- Do not claim an example, diagram, test, benchmark, or generator is verified unless it has actually been run against the stated revision and scope.

## Workflow

- Work on `development`; `master` represents the released baseline.
- Keep the repository to the intended `master` and `development` branches. Do not create or preserve side branches without a concrete need.
- Inspect the current tree and branch state before editing. Do not overwrite intervening changes: fetch the current file and use its current blob SHA for updates.
- Make focused, reviewable commits on `development`.
- Run the relevant build and tests after code changes; report exact commands and outcomes.
- Update user-facing docs when behavior or contracts change. Use the canonical Workshop moniker header where appropriate and the exact canonical PNG footer at the end of each Markdown document.
- NuGet publication is forbidden unless the repository owner explicitly declares the release. A manual workflow input alone is not authorization. Never dispatch a publishing workflow or push a package as part of ordinary development.
- Do not merge branches, delete branches, create releases, or publish packages without explicit owner authorization.

## Documentation and evidence

Documentation must be operational and explanatory, not an internal TODO ledger. Keep one authoritative home for each contract. Separate implemented behavior, source-checked behavior, conceptual models, and planned work. UML coverage must be inventoried honestly; do not imply repository-wide source generation when diagrams are hand-authored.

## Completion report

For each substantial task, report:
- what changed and why;
- files and commit SHA;
- build/test/CI evidence and exact scope;
- remaining risks or unverified work;
- whether any release-sensitive operation occurred (normally: none).

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop avatar" width="200" /></p>
