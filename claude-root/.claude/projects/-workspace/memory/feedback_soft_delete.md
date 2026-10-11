---
name: Soft delete pattern
description: Never hard-delete records; always soft-delete via RecordStateId on CmEntity
type: feedback
originSessionId: 6fbd8053-d104-463e-b826-a46734dee71c
---
Never use hard deletes (Remove/Delete from DbContext). Every entity extends CmEntity which has RecordStateId. A "delete" means setting RecordStateId = (int)RecordStateTypeId.Deleted and calling UpdateAsync.

**Why:** The DB design is built around record lifecycle — Active (1000), Deleted (1001), Archived (1002). Hard deletes destroy audit history and break referential integrity across the temporal data model.

**How to apply:** In BaseRepository.DeleteAsync, set RecordStateId to Deleted and call UpdateAsync. GetAllAsync and GetAsync(predicate) always filter to RecordStateId == Active only.
