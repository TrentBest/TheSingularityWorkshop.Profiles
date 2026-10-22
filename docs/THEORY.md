# Profiles Theory

## 1. Entity before application

The central idea of Profiles is that an application should not have to invent a different identity abstraction for every kind of thing it can represent.

A person, company, guild, game world, autonomous agent, or custom business entity can all participate in the same ecosystem through a common semantic boundary.

~~~text
                    Entity
                      |
        +-------------+-------------+
        |             |             |
     person        company       experience
        |             |             |
        +-------------+-------------+
                      |
                    Profile
~~~

ProfileEntityKind identifies the broad kind of entity. The rest of the application can remain free to specialize behavior.

This is deliberately not a database inheritance hierarchy.

## 2. Identity is not presentation

A canonical identity answers:

> Which entity is this?

A representation answers:

> What may this observer receive about that entity?

Those questions must remain separate.

~~~text
Canonical Profile
       |
       | disclosure policy
       v
Observer-specific Representation
~~~

Two observers can therefore receive different representations of the same profile without creating two canonical identities.

## 3. Micro-data

Profiles treats individual claims as small units of information.

Instead of giving an application the entire user record, the model encourages giving it the one proposition or attribute it actually needs.

This is the package's micro-data principle.

A claim such as language, age, role, or capability can have an independent disclosure rule.

That makes least-privilege behavior expressible in the domain model. Least-privilege enforcement still depends on the host protecting the original profile and applying authorization consistently across every access path.

## 4. Representation is an information boundary

ProfileRepresentation is not merely a view-model convenience.

It is the semantic boundary between owned information and observer-visible information. It is not, by itself, an enforcement boundary for the whole application: code that can read the original Profile object can still read its claims.

~~~text
Profile
  = owned domain information

Representation
  = authorized projection
~~~

An application should be able to reason about the difference explicitly.

An excluded observer receives a representation that retains the stable ProfileId but has a null display name, the literal `anonymous` avatar, and no claims. This is the exact projection behavior, not revocation of access to a Profile object already held elsewhere.

## 5. Unknown is a first-class result

Experiences frequently need propositions rather than raw facts.

For example:

~~~text
Does this participant satisfy Age >= 21?
~~~

The useful result is:

~~~text
Satisfied
NotSatisfied
Unknown
~~~

The default `ProfileAssumptionResolver` maps `KeyNotFoundException` and `InvalidOperationException` thrown by the configured predicate to `Unknown`. It maps a normal boolean result to `Satisfied` or `NotSatisfied`; other exceptions are not swallowed.

This is a small in-process predicate contract, not a privacy-preserving proof engine. The predicate receives the original `Profile` and may inspect raw claims. If an experience needs to avoid disclosing the underlying value, it must design a trusted resolver and host boundary that actually enforce that requirement.

## 6. Verification is separate from assertion

`ProfileClaim` carries an optional provenance string and optional verification timestamp; `IsVerified` means only that the timestamp is present. These fields are metadata, not independent verification, validation of provenance, expiry handling, or proof that the source is authoritative.

A host may compose a trusted verification provider with the profile and its assumption resolver. That integration is a future/host capability, not behavior performed automatically by this package. The neutral domain does not establish the provider's authority or validate evidence.

## 7. Identity sovereignty

A canonical identity does not need to be the same identity a person presents publicly.

A creator may need a canonical account identity, publisher identity, commercial identity, and experience-specific identity.

Private identity links allow trusted infrastructure to maintain those relationships without forcing ordinary observers to learn them.

The linkage itself is sensitive information.

## 8. Disclosure is not licensing

Profiles deliberately distinguishes:

~~~text
Disclosure
    = a configured rule allows a representation to include information.

Verification
    = a trusted process establishes a proposition (not supplied by the core).

Licensing
    = the owner enables a policy and allow-lists eligible keys.
~~~

None of these should silently imply another.

A public attribute is not automatically for sale.

A verified proposition does not require revealing the underlying value.

A licensing policy does not execute a transaction.

## 9. Access transparency without surveillance

An owner should be able to know who accessed their information.

That does not imply that the owner should automatically receive all private information about the accessor.

The access boundary is intentionally narrow:

~~~text
Profile
  |
  +-- who accessed me?
  +-- when?
~~~

Transparency about access is not a blanket authorization to inspect the accessor.

## 10. Groups are policy vocabulary

Groups are not only social constructs.

They provide a reusable vocabulary for friends, family, coworkers, customers, guild members, trusted creators, and application-specific audiences.

In the current implementation, profile-owned group membership can affect Group disclosure rules and group-avatar selection. Groups do not automatically grant permissions for unrelated actions, and arbitrary relationships are not consulted by `RepresentTo`.

## 11. Provider neutrality

Profiles is deliberately independent of authentication vendors, databases, cloud providers, payment providers, rendering frameworks, web frameworks, and jurisdiction-specific services.

Adapters can be composed around it.

## 12. Ecosystem role

Profiles belongs above raw persistence and below application experiences.

~~~text
Persistence / external systems
            |
            v
      Integration layer
            |
            v
         Profiles
            |
            v
   Authorization / policy
            |
            v
       Experiences
~~~

The Workshop can therefore use Profiles as a common language while different Experiences remain free to build their own worlds.

## 13. The deeper abstraction

The most important abstraction is the relationship:

~~~text
Entity + information + disclosure policy + observer context
                              |
                              v
                 observer-specific representation
~~~

The current implementation evaluates per-claim rules and display-name visibility, resolves an avatar, and returns a read-only claims dictionary. The SVG linked from the README visualizes that exact boundary and labels what was and was not used to create it.

That relationship is what allows a shared ecosystem to contain many kinds of software without requiring every application to own or understand every user's entire identity record.

> The profile owns the boundary. The observer receives the representation.


## 14. Mathematical security theory and enforcement

SingularityWarehouse's set-based, mathematically bounded security theory is a potential foundation for precise policy reasoning. Profiles should remain compatible with that direction without making its implementation mandatory.

Keep the distinction explicit:

- **Model:** defines entities, claims, observers, policies, and the representation intended for an observer.
- **Decision:** evaluates whether a requested operation is permitted under the applicable policy.
- **Enforcement:** prevents disallowed operations across application code, endpoints, storage, transport, and integrations.

A mathematical bound can make a model precise; it does not automatically ensure that a host application invokes the model correctly or protects every route to the underlying data. Profiles implements a limited domain model, not a complete security enforcement system.

This separation allows a future security package or host application to adopt set-based, capability-based, or other appropriate enforcement mechanisms while Profiles stays neutral and reusable.


## 15. A profile is a policy input, not a universal permission token

A profile can help an application express what information is associated with an entity and which claims belong in a particular representation. It does not, by itself, decide every operation that the entity, observer, or application may perform.

For example, allowing an observer to receive a public language claim does not permit that observer to edit the profile, call a tool, enter a private group, read a database row, or purchase another claim. Those are separate operations with their own authorization and enforcement rules.

A useful consumer flow is:

~~~text
trusted host establishes observer identity
                  |
                  v
host supplies trusted group context
                  |
                  v
Profile.RepresentTo(observer, groups)
                  |
                  v
consumer receives filtered projection
                  |
                  v
host separately enforces operation permissions
~~~

The observer ID and any externally supplied group IDs must come from trusted host logic. RepresentTo accepts group context as input; it cannot establish whether that context is truthful. The host must not let an untrusted caller choose arbitrary group IDs to widen their own disclosure.

## 16. Mutability, snapshots, and lifecycle ownership

Profiles is an in-process domain model, not an immutable database snapshot. The Profile remains mutable: a host may change its display name, claims, disclosure rules, groups, relationships, exclusions, and avatar choices. A representation copies its claims collection at creation time, so later changes to the source collection do not change the representation's key/value membership. However, arbitrary CLR claim values are not deep-cloned; mutable objects stored as claim values can still be shared by reference.

This has three practical consequences:

1. Prefer immutable claim values, or copy/serialize them at the application boundary when isolation is required.
2. Create a fresh representation when the host needs a projection reflecting current profile state.
3. Define persistence, concurrent mutation, revocation, retention, and audit semantics in the consuming application; the package does not supply a storage transaction or automatically invalidate copies already handed to consumers.

An exclusion affects future calls to RepresentTo; it cannot retract information that another component has already copied, observed, cached, or transmitted. This is why privacy requires both a precise domain model and careful host-level lifecycle and enforcement decisions.
