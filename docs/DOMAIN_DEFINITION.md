# Profiles Domain Definition

This document defines the semantic territory owned by `TheSingularityWorkshop.Profiles`. It is the domain contract to audit against the public API, tests, XML documentation, and consuming examples before the next package release.

## 1. The domain in one sentence

**Profiles models an entity's domain identity, its independently addressable information and relationships, and the observer-specific representation that disclosure policy permits.**

A Profile can describe an individual, company, group, organization, experience, agent, or application-defined entity. These are semantic categories, not database tables or a prescribed inheritance hierarchy.

## 2. Core vocabulary

| Term | Domain meaning | Must not be confused with |
|---|---|---|
| Entity | The thing being described | A login, database row, or UI component |
| Profile | The domain boundary and owner of profile information | The representation sent to an observer |
| Profile ID | Stable, opaque identity within the host's chosen identity scheme | Proof of real-world identity or authentication |
| Claim / micro-data | One typed, independently addressable assertion about an entity | A verified fact merely because it is stored |
| Provenance | Information about where a claim came from | A trusted authority or proof by itself |
| Verification | A result established against an explicit standard by a trusted process | A timestamp, self-assertion, or disclosure permission |
| Disclosure rule | Policy describing which observers/audiences may receive a claim | Authentication or complete access control by itself |
| Observer | The profile ID requesting a representation | A verified principal unless the host establishes that fact |
| Representation | A policy-filtered projection for an observer | The canonical Profile or a security sandbox |
| Group / membership | A domain audience relationship used by disclosure policy | Trusted membership unless the source of membership is trusted |
| Relationship | A typed semantic link between profiles | An implicit permission grant |
| Exclusion | An explicit owner decision that limits an observer's representation | Revocation of access to a Profile object already held elsewhere |
| Assumption | A proposition an experience asks the domain to resolve | Proof that its input claims are authoritative |
| Identity link | A private relation between canonical and presentation profiles | Public profile data or an ordinary observer-visible relationship |
| External identity reference | Provider/issuer-qualified subject reference | Credentials or proof of authentication |
| Exposure report | Metadata describing what is publicly exposed | A copy of private claim values |
| Access record | Minimal event metadata supporting transparency | Permission to inspect the observer's private motivation |
| Data-license policy | Explicitly opted-in conditions describing potential data use | A sale, contract, payment, or settlement |

## 3. Core responsibilities

Profiles owns the neutral semantics and in-process contracts for:

1. **Entity description** — profile identity, broad entity kind, and display-level domain attributes.
2. **Micro-data** — typed claims with independent keys and optional provenance/verification metadata.
3. **Disclosure** — claim-level audience policy and observer-specific projection.
4. **Social structure** — profile-owned groups, memberships, relationships, and exclusions.
5. **Assumptions** — proposition outcomes that preserve `Satisfied`, `NotSatisfied`, and `Unknown` as distinct states.
6. **Identity sovereignty** — private canonical-to-persona/publisher/commercial profile links and provider-qualified external identity references.
7. **Transparency metadata** — public exposure reporting and minimal access-record contracts.
8. **Opt-in data-use policy** — a domain distinction between disclosure and permission for a defined use.

## 4. Invariants the implementation must preserve

These are the intended release invariants. Each must be backed by focused tests and documentation that matches the actual public API.

- **Identity is not presentation.** Two observers may receive different representations of one Profile without creating different canonical identities.
- **Adding a claim does not publish it.** Disclosure is explicit; the absence of a rule must never accidentally broaden disclosure.
- **Disclosure is per claim.** Permission to receive one claim does not imply permission to receive unrelated claims.
- **Unknown is not false.** Missing, invalid, or unresolved input must not be silently converted to `NotSatisfied` unless a specific, documented resolver defines that behavior.
- **Assertions are not verification.** Stored values, provenance, and timestamps do not establish trust or legal authority on their own.
- **Groups and relationships are not implicit grants.** Only documented disclosure rules and trusted host-provided membership context may influence the audience decision.
- **Exclusion is conservative.** An excluded observer's representation must not expose ordinary profile claims or private identity links.
- **Private identity links stay private.** They must not leak through ordinary representations, exposure reports, or public relationship enumeration.
- **Projection is not object protection.** A `ProfileRepresentation` limits what it contains; it cannot protect the original `Profile` if the host passes that object to untrusted code.
- **Claim values have explicit mutability limits.** Collection wrappers and copies do not deep-clone arbitrary CLR objects. API docs and tests must make this boundary clear; immutable values are preferred.
- **Disclosure is not licensing.** Public availability does not authorize sale or another economic use.
- **No infrastructure assumptions.** The core does not require a database, network, identity provider, renderer, FSM_COS, or Workshop application.

## 5. Responsibilities outside the package

| Responsibility | Owner |
|---|---|
| Persistence, replication, retention, deletion, backup | Consuming application / storage adapter |
| Authentication and trusted principal establishment | Host identity provider / authentication integration |
| Authorization at API, database, transport, plugin, and process boundaries | Host application and security infrastructure |
| Claim verification, issuer trust, evidence validation, expiry and revocation authority | Trusted verification provider |
| UI, avatar rendering, audio, haptics, spatial LOD | Presentation and sensory systems |
| Network protocols and remote access | Transport/service layer |
| Jurisdictional decisions and legal process | Appropriate policy, authority, and legal layer |
| License negotiation, price, contract, consent workflow, payment, settlement | Explicit marketplace/economic infrastructure |

The domain may define integration contracts and values used by these layers, but must not claim to perform their jobs merely by carrying their metadata.

## 6. Observer representation flow

```text
trusted host establishes observer identity/context
                  |
                  v
             Profile + claims
                  |
                  v
        disclosure / membership / exclusion
                  |
                  v
        observer-specific representation
                  |
                  v
      host-controlled handoff to consumer
```

The host is responsible for protecting the original Profile and for supplying trustworthy observer and membership context. A representation is the intended least-disclosure handoff, not a substitute for endpoint authorization.

## 7. Assumption result semantics

- `Satisfied`: the configured resolver concluded that the proposition is satisfied under its stated rules.
- `NotSatisfied`: the resolver concluded that the proposition is not satisfied under its stated rules.
- `Unknown`: the resolver cannot responsibly decide from available or valid input.

The result is only as trustworthy as the resolver, inputs, and proof semantics. The neutral core must not imply that an in-process predicate establishes independent verification.

## 8. Domain boundaries to keep separate

- **Profile vs. representation:** owned domain state vs. observer-filtered projection.
- **Claim vs. verification:** assertion vs. established result.
- **Disclosure vs. authorization:** policy value/projection vs. enforcement across all access paths.
- **Identity vs. persona:** canonical identity vs. a chosen presentation identity.
- **Disclosure vs. licensing:** permission to receive information vs. explicitly permitted economic use.
- **Access transparency vs. surveillance:** minimal information about access vs. unrelated private information about the accessor.
- **Domain contract vs. infrastructure:** portable semantics vs. persistence, transport, UI, and external authority.

## 9. Release audit checklist

Before the next NuGet package is released:

- [ ] Every public type and member maps to this vocabulary or is removed/renamed with a documented compatibility decision.
- [ ] Disclosure defaults, unknown keys, exclusions, group context, and identity-link visibility have negative tests.
- [ ] Mutable claim values and collection-copy behavior are explicit in API docs and tested where possible.
- [ ] Assumption results and resolver limitations are tested and shown in a compiling consumer example.
- [ ] README, architecture, theory, privacy, API, consuming, and how-to docs agree with source behavior.
- [ ] Navigation links and packaged documentation assets are verified.
- [ ] Restore, build, tests, coverage, XML documentation, and NuGet package audit pass on `development`.
- [ ] The explicit manual publish gate and Trusted Publishing configuration are verified without accidentally publishing.

This document defines the domain target; it is not evidence that every invariant has already been implemented or verified. Implementation status must be established from source, tests, CI, and the packed artifact.
