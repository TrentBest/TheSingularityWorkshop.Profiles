<!-- The Singularity Workshop moniker -->
<p align="center"><a href="https://github.com/TrentBest"><img src="https://raw.githubusercontent.com/TrentBest/TheSingularityWorkshop.Visualize/development/docs/assets/moniker.svg" alt="The Singularity Workshop animated moniker" width="720" /></a></p>

# ProfileAccessRecord

## 1. What

`ProfileAccessRecord` is a sealed record representing a profile access event with three values: the accessed `ProfileId`, the `Observer` `ProfileId`, and the `DateTimeOffset` `AccessedAt` timestamp.

**Source:** [ProfileAccessLog.cs](../../ProfileAccessLog.cs)

## 2. Why

Access transparency needs a compact event contract that identifies which profile was accessed, which observer was recorded, and when the event occurred. Keeping the record limited to these values avoids embedding an observer's private reason for access in the core domain event.

The record does not establish that an access was authenticated, authorized, successful, or lawful. It also does not define retention, audit integrity, storage, or user-facing disclosure of access history.

## 3. How

- `ProfileId` identifies the profile that was accessed.
- `Observer` identifies the observer recorded for the event.
- `AccessedAt` carries the event timestamp as a `DateTimeOffset`.

The positional record provides value-based record semantics. The declaration contains no persistence behavior, validation policy, reason field, or relationship to a particular storage technology. The owning host determines when an event should be emitted and how it is stored, protected, retained, and presented.

## 4. See it in a minute

```csharp
var access = new ProfileAccessRecord(
    ProfileId: profileId,
    Observer: observerId,
    AccessedAt: DateTimeOffset.UtcNow);

recorder.Record(access);
```

This example records the event through the separate recorder abstraction. It does not imply that constructing the record alone persists anything.

## 5. Choose your next step

- Review [IProfileAccessRecorder](IProfileAccessRecorder.md) for the receiving abstraction.
- Review [ProfileId](ProfileId.md) for identity value semantics.
- Review [Privacy](../PRIVACY.md) for disclosure boundaries and host responsibilities.
- Add host-level tests for persistence, retention, and access-history presentation; those behaviors are not implemented by this record.


<!-- THE SINGULARITY WORKSHOP FOOTER -->
<p align="center"><img src="https://raw.githubusercontent.com/TrentBest/FSM_API/master/Documentation/Branding/TheSingularityWorkshop.png" alt="The Singularity Workshop" width="200" /></p>
