<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles public type reference

This directory documents individual public types. Source and XML API documentation remain authoritative for exact member contracts; these pages explain purpose, boundaries, relationships, ownership, mutability, limitations, and evidence.

## Current coverage

| Type | Source | Documentation |
|---|---|---|
| `ProfileId` | [ProfileId.cs](../../ProfileId.cs) | [ProfileId](ProfileId.md) |
| `ProfileEntityKind` | [ProfileEntityKind.cs](../../ProfileEntityKind.cs) | [ProfileEntityKind](ProfileEntityKind.md) |
| `Profile` | [Profile.cs](../../Profile.cs) | [Profile](Profile.md) |
| `ProfileAttributeDefinition` | [ProfileAttributeDefinition.cs](../../ProfileAttributeDefinition.cs) | [ProfileAttributeDefinition](ProfileAttributeDefinition.md) |
| `ProfileClaim` | [ProfileClaim.cs](../../ProfileClaim.cs) | [ProfileClaim](ProfileClaim.md) |
| `DisclosureScope` | [Disclosure.cs](../../Disclosure.cs) | [DisclosureScope](DisclosureScope.md) |
| `DisclosureRule` | [Disclosure.cs](../../Disclosure.cs) | [DisclosureRule](DisclosureRule.md) |
| `ProfileRepresentation` | [ProfileRepresentation.cs](../../ProfileRepresentation.cs) | [ProfileRepresentation](ProfileRepresentation.md) |
| `ProfileGroup` | [ProfileGroup.cs](../../ProfileGroup.cs) | [ProfileGroup](ProfileGroup.md) |
| `ProfileRelationship` | [ProfileRelationship.cs](../../ProfileRelationship.cs) | [ProfileRelationship](ProfileRelationship.md) |
| `ProfilePublicDataReport` | [ProfilePublicDataReport.cs](../../ProfilePublicDataReport.cs) | [ProfilePublicDataReport](ProfilePublicDataReport.md) |
| `ProfilePublicDataReporter` | [ProfilePublicDataReport.cs](../../ProfilePublicDataReport.cs) | [ProfilePublicDataReporter](ProfilePublicDataReporter.md) |
| `ProfileIdentityLink` | [ProfileIdentityLink.cs](../../ProfileIdentityLink.cs) | [ProfileIdentityLink](ProfileIdentityLink.md) |
| `ProfileIdentityLinkKind` | [ProfileIdentityLink.cs](../../ProfileIdentityLink.cs) | [ProfileIdentityLinkKind](ProfileIdentityLinkKind.md) |
| `ProfileIdentityLinkStore` | [ProfileIdentityLinkStore.cs](../../ProfileIdentityLinkStore.cs) | [ProfileIdentityLinkStore](ProfileIdentityLinkStore.md) |
| `ExternalIdentityReference` | [ExternalIdentityBinding.cs](../../ExternalIdentityBinding.cs) | [ExternalIdentityReference](ExternalIdentityReference.md) |
| `ProfileExternalIdentityBinding` | [ExternalIdentityBinding.cs](../../ExternalIdentityBinding.cs) | [ProfileExternalIdentityBinding](ProfileExternalIdentityBinding.md) |
| `AssumptionDefinition` | [Assumptions.cs](../../Assumptions.cs) | [AssumptionDefinition](AssumptionDefinition.md) |
| `AssumptionResultKind` | [Assumptions.cs](../../Assumptions.cs) | [AssumptionResultKind](AssumptionResultKind.md) |
| `AssumptionResult` | [Assumptions.cs](../../Assumptions.cs) | [AssumptionResult](AssumptionResult.md) |
| `IProfileAssumptionResolver` | [Assumptions.cs](../../Assumptions.cs) | [IProfileAssumptionResolver](IProfileAssumptionResolver.md) |
| `ProfileAssumptionResolver` | [Assumptions.cs](../../Assumptions.cs) | [ProfileAssumptionResolver](ProfileAssumptionResolver.md) |

**Coverage status:** 22 of the 25 top-level public declarations have focused type pages. The other 3 types are `ProfileDataLicensePolicy`, `ProfileAccessRecord`, and `IProfileAccessRecorder`; all are inventoried with direct source links in the [UML and type-documentation index](../UML/README.md). The count is a manual inventory of the 16 root-level implementation files on `development`, not a generated or CI-enforced count.

## Recommended documentation batches

1. **Identity and entity:** `ProfileId`, `ProfileEntityKind`, `Profile` — documented.
2. **Claims and disclosure:** `ProfileAttributeDefinition`, `ProfileClaim`, `DisclosureScope`, `DisclosureRule` — documented.
3. **Representation and exposure:** `ProfileRepresentation`, `ProfilePublicDataReport`, `ProfilePublicDataReporter` — documented.
4. **Groups and relationships:** `ProfileGroup`, `ProfileRelationship` — documented.
5. **Assumptions:** `AssumptionDefinition`, `AssumptionResult`, `AssumptionResultKind`, `IProfileAssumptionResolver`, `ProfileAssumptionResolver` — documented.
6. **Identity links and external bindings:** `ProfileIdentityLink`, `ProfileIdentityLinkKind`, `ProfileIdentityLinkStore`, `ExternalIdentityReference`, `ProfileExternalIdentityBinding` — documented.
7. **Licensing and access transparency:** `ProfileDataLicensePolicy`, `ProfileAccessRecord`, `IProfileAccessRecorder` — remaining.

## Page standard

Each page should state its declaration kind, purpose, responsibilities and non-goals, key public members, source-backed relationships, ownership/mutability, examples, relevant tests, limitations, and exact source links. Pair it with a target-centered UML page that distinguishes verified consumers from dependencies and includes human-authored use cases. Do not infer a runtime consumer graph from declaration relationships alone.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
