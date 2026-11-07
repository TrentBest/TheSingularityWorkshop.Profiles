<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# Profiles test traceability

## 01 — What

This page maps the checked-in test suite to the public contracts it exercises. It is a source-to-test inventory, not a claim that the tests were executed during this documentation pass.

## 02 — Why

A public type having a focused reference page does not mean every behavior has an automated assertion. This matrix separates direct behavioral assertions from compile-checked consumer examples and makes the remaining test gaps explicit.

## 03 — How: contract-to-test matrix

**Scope inspected:** `tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs`, `ConsumerGuideExamplesTests.cs`, and `ProfileDataLicensePolicyTests.cs` on `development`, 2026-11-07. Test names below are present in source. No build or test command was run for this inventory.

| Contract / behavior | Direct test evidence | Coverage assessment |
|---|---|---|
| Entity kinds and profile identity | `AllSupportedEntityKindsCanBeRepresented`, `ProfileIdsAreOpaqueAndUnique` | Direct assertions for supported kinds, initialized IDs, uniqueness, and nonblank formatting |
| Collection encapsulation and representation copying | `PublicCollectionViewsCannotMutateProfileInternals`, `RepresentationCopiesAndProtectsItsClaimsCollection` | Direct assertions for selected read-only/snapshot collection contracts; representation claims copy is shallow |
| Attribute definitions and claims | `AttributeDefinitionsValidateEveryPublicConstructionPath`, `ClaimsEnforceDeclaredValueType`, `ClaimsRetainVerificationAndProvenance` | Constructor validation, CLR value-type enforcement, and metadata retention covered; semantic validity and trustworthiness of provenance are not established |
| Disclosure-rule audience contracts | `DisclosureRuleAudienceTypesCannotBeConfused`, `DisclosureRulesRejectUninitializedAudienceIds`, `DisclosureRuleRejectsUninitializedRequesterGroupIds` | Scope-specific audience separation, defensive audience copying, and invalid-ID rejection covered |
| Claim disclosure and projection | `ProfileConfigurationCanBeFluent`, `PublicClaimIsIncluded`, `PrivateClaimDoesNotLeak`, `ExplicitClaimIsVisibleOnlyToAllowedObserver`, `GroupDisclosureRevealsOnlyToGroupMembers`, `RepresentationOverrideCanReplaceSensitiveValue` | Main public/private/explicit/group paths, group membership integration, and value override covered |
| Display-name and exclusion behavior | `DisplayNameRequiresItsOwnDisclosureRule`, `DisplayNameDisclosureOverrideReplacesCanonicalDisplayName`, `ExcludedObserverReceivesOnlyAnonymousRepresentation`, `RemovingExclusionRestoresNormalRepresentation` | Dedicated assertions for display-name rule/override and exclusion/restore paths |
| Avatar selection | `GroupAvatarOverridesPublicAvatar`, `DirectAvatarOverridesGroupAndPublicAvatars`, plus `ProfileConfigurationCanBeFluent` | Group/direct precedence and public avatar baseline covered; exhaustive fallback combinations are not separately enumerated |
| Observer/group input validation | `UninitializedObserverIdsAreRejectedAtDisclosureBoundaries`, `RepresentationRejectsUninitializedObserverGroupIds` | Selected disclosure boundaries reject default IDs |
| Group lifecycle and membership | `DefiningAnExistingGroupPreservesItsMembership`, `GroupsManageMembership` | Existing-group reuse and add/contains/remove behavior covered |
| Relationships | `RelationshipsRejectUninitializedEndpointsAndBlankTypes`, `RelationshipsMustBelongToTheirSubject` | Endpoint/type validation and subject ownership covered |
| Public exposure metadata | `PublicDataReportContainsExposureMetadataOnly`, `PublicDataReportIgnoresRulesWithoutMatchingClaims` | Metadata projection and ignoring unmatched disclosure rules covered; no assertion that metadata proves actual external visibility |
| Assumption definitions and outcomes | `AssumptionDefinitionsRejectInvalidContractsAndRemainDeconstructable`, `AssumptionCanBeSatisfied`, `AssumptionCanBeNotSatisfied`, `UnknownAssumptionIsNotNotSatisfied` | Definition validation and three outcome categories covered; absent claim exercises the unknown path |
| Identity-link contracts/store | `IdentityLinksRemainPrivateToTrustedInfrastructure`, `IdentityLinkStoreRejectsSelfLink`, `IdentityLinkStoreDoesNotDuplicateLinks`, `IdentityLinksRejectUninitializedIdsAndUnknownKinds` | Construction validation, self-link rejection, duplicate suppression, and a basic lookup covered; reverse-order lookup and all enum-kind semantics are not exhaustively asserted |
| External identity mapping | `ExternalIdentityRequiresIssuerAndSubject`, `ExternalIdentityBindingRequiresInitializedProfileId` | Required fields and initialized profile association covered; issuer verification, caller authentication, ownership proof, and authorization are intentionally outside this contract |
| Licensing policy | `LicensingRequiresExplicitEnablementAndAttributeAllowList` and all three tests in `ProfileDataLicensePolicyTests.cs` | Enablement, allow-list, disallow, key validation, and defensive snapshot covered |
| Access record | `AccessRecordCapturesOnlyProfileObserverAndTime` | Record data shape covered; no test of an `IProfileAccessRecorder` implementation because persistence/processing belongs to the host |
| Consumer onboarding examples | Four tests in `ConsumerGuideExamplesTests.cs` | Claim disclosure, group/avatar, assumption/licensing, and private identity-link examples compile and run as tests; these are examples, not exhaustive contract suites |

### Explicit gaps and limits

- **Assumption resolver exception matrix:** the missing-claim test exercises the `KeyNotFoundException` → `Unknown` path. The inspected tests do not directly assert the `InvalidOperationException` mapping or propagation of unrelated exception types.
- **Access recording:** the repository defines the record and recorder interface; it does not own a persistence implementation. No host recorder behavior is covered here.
- **External identity trust:** tests validate data construction only. They do not, and should not be read to, prove issuer authenticity, subject ownership, caller authentication, or authorization.
- **Identity-link store:** tests cover a basic link lookup and duplicate handling, but do not comprehensively assert symmetric queries, concurrent access, persistence, or authorization.
- **Public data report:** tests cover configured metadata. They do not establish what a particular observer can actually retrieve from a host.
- **Security and integration:** this matrix is not a penetration test, privacy audit, integration test inventory, or proof of deployment configuration.
- **Execution status:** inspecting test source is not running tests. CI/build status must be checked separately for the relevant commit.

## 04 — See it in a minute

Start with [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs) for domain behavior, [ProfileDataLicensePolicyTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileDataLicensePolicyTests.cs) for licensing edge contracts, and [ConsumerGuideExamplesTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ConsumerGuideExamplesTests.cs) for compile-checked onboarding examples.

## 05 — Choose your next step

- [UML inventory](README.md) for structural, sequence, and documentation coverage.
- [Interaction sequences](InteractionSequences.md) for source-backed representation and assumption flows.
- [Type reference index](../Types/README.md) for all 25 inventoried public declarations.
- [Architecture](../ARCHITECTURE.md) and [privacy model](../PRIVACY.md) for ownership and trust boundaries.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
