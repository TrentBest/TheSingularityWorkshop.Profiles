<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# `ProfileRepresentation`

## 01 — What

`ProfileRepresentation` is a sealed record containing an observer-specific projection: profile ID, permitted display name, permitted avatar, and a claims dictionary.

Source: [ProfileRepresentation.cs](../../ProfileRepresentation.cs).

## 02 — Why

Consumers should receive the representation produced for their viewing context rather than being handed the mutable `Profile` aggregate and expected to apply disclosure rules themselves.

This is a projection contract, not an authenticated session, authorization token, encryption envelope, or proof that claim values are true.

## 03 — How

The constructor requires a non-null claims dictionary and copies its entries into a new dictionary using ordinal string-key comparison. It exposes that copy through `ReadOnlyDictionary`. Later changes to the caller's original dictionary do not change the representation, and callers cannot mutate its collection through `Claims`.

The record exposes four get-only properties:

- `Id`: identity of the represented profile.
- `DisplayName`: name selected for this observer.
- `Avatar`: avatar selected for this observer.
- `Claims`: copied, read-only claim-value dictionary.

### Ownership boundary

The copy is shallow. Values typed as `object?` are retained by reference; mutable objects inside the dictionary are not cloned or frozen. Prefer immutable claim values or treat them as immutable after publication. The record's read-only surface protects dictionary structure, not deep object graphs.

The public constructor accepts any `ProfileId`, including the default value; callers constructing representations directly are responsible for supplying a meaningful identity. Normal profile projection obtains the ID from the source `Profile`.

## 04 — See it in a minute

```csharp
var values = new Dictionary<string, object?>
{
    ["language"] = "en-US"
};

var view = new ProfileRepresentation(
    profile.Id,
    "Ari",
    avatarUrl,
    values);

// Later changes to 'values' do not alter view.Claims.
values["language"] = "fr-FR";
Console.WriteLine(view.Claims["language"]); // en-US
```

## 05 — Choose your next step

- [Profile aggregate and observer projection](Profile.md)
- [ProfileClaim](ProfileClaim.md)
- [Implementation](../../ProfileRepresentation.cs)
- [Representation tests](../../tests/TheSingularityWorkshop.Profiles.Tests/ProfileTests.cs)

<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
