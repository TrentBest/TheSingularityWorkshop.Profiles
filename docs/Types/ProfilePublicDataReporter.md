<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfilePublicDataReporter

## 01 — What

`ProfilePublicDataReporter` is a static class that creates an owner-facing [`ProfilePublicDataReport`](ProfilePublicDataReport.md) from a `Profile`.

Source: [ProfilePublicDataReport.cs](../../ProfilePublicDataReport.cs).

## 02 — Why

The reporter provides a small, value-free summary of configured public exposure. It lets a caller inspect which public attribute keys are currently represented by claims and whether display-name/avatar exposure is configured, without copying claim values into the report.

## 03 — How

Its sole public operation is:

```csharp
public static ProfilePublicDataReport Create(Profile profile)
```

The method rejects a null argument, then reads the profile's current public-attribute keys, display-name-public flag, and public-avatar flag. It copies the keys to an array before constructing the report.

This is a snapshot of selected profile configuration at call time. It does not:

- Build an observer-specific representation or evaluate every observer's group membership.
- Return claim values, private attributes, or avatar content.
- Publish, transmit, persist, or audit profile data.
- Authenticate a caller or enforce authorization.
- Guarantee that a host's transport, cache, UI, or storage exposes data in the same way.

A report is therefore an inspection aid, not a security boundary or proof of effective external exposure. Hosts remain responsible for access control, publication, transport, and enforcement.

## 04 — See it in a minute

```csharp
ProfilePublicDataReport exposure = ProfilePublicDataReporter.Create(profile);

bool hasPublicFields = exposure.PublicAttributes.Count > 0;
bool exposesName = exposure.DisplayNameIsPublic;
bool hasAvatar = exposure.HasPublicAvatar;
```

The `PublicDataReportContainsExposureMetadataOnly` test checks the metadata fields without asserting or exposing claim values. `PublicDataReportIgnoresRulesWithoutMatchingClaims` covers a public disclosure rule whose claim is not present.

Test source: [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [ProfilePublicDataReport](ProfilePublicDataReport.md) for the report's data contract.
- [Profile.cs](../../Profile.cs) for the profile state read by the reporter.
- [DisclosureRule](DisclosureRule.md) for configured disclosure policy.
- [ProfileRepresentation](ProfileRepresentation.md) for the observer-specific output path.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
