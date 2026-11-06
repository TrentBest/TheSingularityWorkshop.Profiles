<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles API Map

Use this page to orient yourself among the public domain types. It is a conceptual map, not a complete signature reference; XML API documentation and the source files remain authoritative for exact member contracts. The [public type reference](Types/README.md) tracks per-type documentation coverage, while the [UML inventory](UML/README.md) links every declared top-level public type to its source file.

## Identity and entity

### `ProfileId`

Opaque stable identifier for a profile entity. The value is a `Guid` wrapped in a readonly record struct; `New()` creates an identifier.

### `ProfileEntityKind`

The broad entity categories are Individual, Company, Group, Organization, Experience, Agent, and Custom. This vocabulary is intentionally not a database schema.

### `Profile`

The primary entity/profile boundary. It owns its entity kind, display name, micro-data claims, disclosure rules, groups, relationships, exclusions, avatar policy, and observer-specific representation.

The profile is mutable. Its collection properties expose read-only wrappers or snapshots for structural protection; this does not deep-clone arbitrary claim values.

## Micro-data

### `ProfileAttributeDefinition`

Defines an attribute key, its expected CLR `Type`, and optional description.

### `ProfileClaim`

Stores one typed value with an optional verification timestamp and provenance. The value is checked against the definition's CLR type but retained by reference, not deep-cloned. Prefer immutable values or treat values as immutable after claim creation.

## Disclosure and representation

### `DisclosureScope`

Controls the audience for a claim: Private, Public, Group, or Explicit.

### `DisclosureRule`

Connects an attribute key to a disclosure policy. `AllowedObservers` contains observer IDs for Explicit rules; `AllowedGroups` contains group IDs for Group rules. The constructor rejects audience lists that do not match the selected scope. `RepresentationOverride` substitutes a value for every observer permitted by the rule.

### `ProfileRepresentation`

Observer-specific projection of a profile. Its claims dictionary is copied and read-only, protecting the collection structure but not deep-cloning arbitrary values stored inside it. It is intentionally distinct from the mutable Profile aggregate.

### `ProfilePublicDataReport` and `ProfilePublicDataReporter`

The report contains owner-facing metadata: existing claim keys with Public rules, whether the special `display-name` rule is Public, and whether a public/default avatar is configured. The reporter does not copy claim values and does not calculate the final representation for every possible observer.

## Groups and relationships

### `ProfileGroup`

User-controlled membership collection that can participate in disclosure and avatar selection. Membership is represented by profile IDs; the exposed members collection is a defensive snapshot.

### `ProfileRelationship`

Semantic relationship between two profiles. The relationship vocabulary is application-defined; the type validates initialized endpoints and a non-empty relationship label.

## Assumptions

### `AssumptionDefinition`

Describes a proposition using a stable key, human-readable description, and application-supplied predicate over a Profile.

### `AssumptionResult` and `AssumptionResultKind`

The result carries the assumption key, outcome, and optional proof text. Outcomes are `Satisfied`, `NotSatisfied`, or `Unknown`; Unknown is not equivalent to false.

### `IProfileAssumptionResolver` and `ProfileAssumptionResolver`

The interface is the integration boundary. The default in-process resolver evaluates the supplied predicate against the original Profile. It maps `KeyNotFoundException` and `InvalidOperationException` to `Unknown`; other exceptions may propagate. It does not hide raw claims or establish independent verification.

## Sovereign identity and external bindings

### `ProfileIdentityLink`, `ProfileIdentityLinkKind`, and `ProfileIdentityLinkStore`

Represent and keep private links between canonical and linked profiles. The store is an in-memory implementation for trusted identity infrastructure, not a persistence adapter. Ordinary profile representations do not expose these links.

### `ExternalIdentityReference` and `ProfileExternalIdentityBinding`

A provider-qualified external identity reference and its mapping to a domain profile. The reference contains issuer/provider and subject identifiers, not credentials. The binding is a mapping contract, not caller authentication or authorization; authentication, mapping policy, and protected persistence remain host responsibilities.

## Data licensing

### `ProfileDataLicensePolicy`

Explicit opt-in allow-list for attributes eligible for licensing. It does not create a marketplace offer, obtain transactional consent, settle payment, or perform revocation/expiry workflows.

## Access transparency

### `ProfileAccessRecord` and `IProfileAccessRecorder`

A minimal access event containing profile, observer, and timestamp, plus the boundary through which the host can receive that event. The host supplies persistence, retention, access control, and the decision about when to record an access. Creating a representation does not automatically record an access event.

## Source and test navigation

- [Complete declared-type inventory and UML coverage](UML/README.md)
- [Per-type documentation index](Types/README.md)
- [Aggregate domain UML](UML/ProfileUML.md)
- [Consumer guide](CONSUMING.md)
- [Privacy model](PRIVACY.md)

**Dependency philosophy:** Profiles intentionally has no required dependency on Entity Framework, SQL, HTTP, cloud storage, authentication SDKs, payment SDKs, or rendering frameworks. Consumers compose the package with the infrastructure they already use.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
