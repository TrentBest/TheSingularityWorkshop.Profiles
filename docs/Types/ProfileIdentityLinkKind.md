<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileIdentityLinkKind

## 01 — What

`ProfileIdentityLinkKind` is the enum classifying the reason or category of a private profile identity link.

**Declaration:** public enum with four values: `Persona`, `Publisher`, `Commercial`, and `Custom`.

## 02 — Why

The category gives trusted identity infrastructure a small, explicit vocabulary for describing why two profiles are associated without placing the association in ordinary public profile data.

The enum is descriptive metadata. A value such as `Publisher` does not prove that the linked profile is a publisher, that the profiles share an owner, or that a third party has verified the relationship.

## 03 — How

`ProfileIdentityLink` validates values with `Enum.IsDefined` and rejects undefined numeric values. The enum does not define authorization rules, disclosure policy, legal classifications, or a registry of custom meanings.

Source: [ProfileIdentityLink.cs](../../ProfileIdentityLink.cs). Related: [ProfileIdentityLink](ProfileIdentityLink.md).

## 04 — See it in a minute

```csharp
var kind = ProfileIdentityLinkKind.Publisher;
var link = new ProfileIdentityLink(canonicalId, publisherId, kind);
```

Both IDs must be initialized and distinct. The enum selection alone does not verify the relationship.

Relevant test: `IdentityLinksRejectUninitializedIdsAndUnknownKinds`.

## 05 — Choose your next step

- [Private link value](ProfileIdentityLink.md)
- [Link store](ProfileIdentityLinkStore.md)
- [External identity reference](ExternalIdentityReference.md)


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
