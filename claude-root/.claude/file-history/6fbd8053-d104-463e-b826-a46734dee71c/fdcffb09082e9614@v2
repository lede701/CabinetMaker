---
name: No magic numbers — use enums
description: All integer type IDs and state values must be expressed as enums, cast to int for DB storage
type: feedback
originSessionId: 6fbd8053-d104-463e-b826-a46734dee71c
---
Never use magic number literals for type IDs, state IDs, or any domain integer constants. Always define an enum and cast: (int)RecordStateTypeId.Active, (int)UnitTypeId.Length, etc.

**Why:** User explicitly required this — magic numbers are unreadable and error-prone across a large type/classification system.

**How to apply:** Enums live in CabinetMaker.Domain/Enums/. Current enums: RecordStateTypeId (1000/1001/1002), UnitTypeId (Length=2000), TypeClassId (RecordState=1, UnitType=2), FractionPrecision (8/16/32/64).
