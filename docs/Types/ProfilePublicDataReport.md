<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfilePublicDataReport

## 01 — What

`ProfilePublicDataReport` is a sealed positional record describing selected public-exposure metadata for one profile.

Its fields are:

- `ProfileId`: the profile being reported.
- `PublicAttributes`: attribute keys currently reported as public.
- `DisplayNameIsPublic`: whether the profile marks its display name public.
- `HasPublicAvatar`: whether a public avatar is configured.

Source: [ProfilePublicDataReport.cs](../../ProfilePublicDataReport.cs).

## 02 — Why

Owners need a compact view of what profile data is configured for public disclosure without receiving the underlying private claim values. The report is metadata, not a copy of a public representation.

## 03 — How

The report is created by [`ProfilePublicDataReporter.Create`](ProfilePublicDataReport.cs). The reporter:

1. Rejects a null profile.
2. Copies `Profile.PublicAttributeKeys` into an array.
3. Reads `IsDisplayNamePublic` and `HasPublicAvatar`.
4. Returns the profile ID and those exposure indicators.

The report contains no claim values, avatar payload, observer-specific result, or group/explicit audience calculation. In particular, it does not prove that a value will be visible to every observer or that a host has published it.

The record's `IReadOnlyList<string>` contract is an interface-level read-only view; the current reporter supplies a fresh array. Consumers should treat the returned collection as report data and avoid relying on stronger deep-immutability guarantees.

## 04 — See it in a minute

```csharp
ProfilePublicDataReport report = ProfilePublicDataReporter.Create(profile);

foreach (string key in report.PublicAttributes)
{
    Console.WriteLine(key);
}

Console.WriteLine($"Display name public: {report.DisplayNameIsPublic}");
Console.WriteLine($"Public avatar configured: {report.HasPublicAvatar}");
```

The source test `PublicDataReportContainsExposureMetadataOnly` verifies the reported profile ID, public attribute key, display-name flag, and avatar flag. `PublicDataReportIgnoresRulesWithoutMatchingClaims` verifies that a public rule for an absent claim is not listed and that the special display-name indicator is separate from `PublicAttributes`.

Test source: [ProfileTests.cs](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs).

## 05 — Choose your next step

- [ProfilePublicDataReport.cs](../../ProfilePublicDataReport.cs) for the exact record and reporter implementation.
- [DisclosureRule](DisclosureRule.md) for audience and scope policy.
- [ProfileRepresentation](ProfileRepresentation.md) for an observer-specific projection.
- [Privacy model](../PRIVACY.md) for the broader disclosure boundary.

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
