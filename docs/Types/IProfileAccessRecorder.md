<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# IProfileAccessRecorder

## 1. What

`IProfileAccessRecorder` is a public interface defining one operation, `Record(ProfileAccessRecord access)`, for receiving profile-access events.

**Source:** [ProfileAccessLog.cs](../../ProfileAccessLog.cs)

## 2. Why

The Profiles domain can describe an access event without owning the host's audit infrastructure. This interface provides a narrow handoff point so a consuming application can decide how to persist or process access records without coupling the domain package to a database, logging vendor, transport, or retention system.

## 3. How

- `Record` accepts a `ProfileAccessRecord` describing the profile, observer, and timestamp.
- The interface declares no return value, query API, storage implementation, transaction boundary, or delivery guarantee.
- The implementation belongs to the owning host or infrastructure layer.

The interface itself does not guarantee durable storage, tamper resistance, ordering, deduplication, access authorization, or successful completion beyond whatever behavior the implementation provides. A host should define and test those guarantees explicitly. The contract also does not carry the observer's private reason for access.

## 4. See it in a minute

```csharp
public sealed class ApplicationAccessRecorder : IProfileAccessRecorder
{
    public void Record(ProfileAccessRecord access)
    {
        // Persist or process the event using host-owned infrastructure.
    }
}
```

This is an illustrative adapter shape, not an implementation supplied by the Profiles library.

## 5. Choose your next step

- Review [ProfileAccessRecord](ProfileAccessRecord.md) for the event data contract.
- Review [Architecture](../ARCHITECTURE.md) for domain-versus-host ownership.
- Implement persistence and retention in the consuming host, with tests for the guarantees that host promises.


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
