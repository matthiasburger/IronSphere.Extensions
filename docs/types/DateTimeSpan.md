[back](/IronSphere.Extensions/types)

# DateTimeSpan

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class describes a range between two date-times

```csharp
public class DateTimeSpan : Object, IEnumerable<DateTime>, IEnumerable
```
Inheritance: Object


Implements:

* System.Collections.Generic.IEnumerable<System.DateTime>
* System.Collections.IEnumerable

| Constructor | Description |
| --- | --- |
| [DateTimeSpan(DateTime start, DateTime end)](DateTimeSpan_DateTimeSpan(DateTime,DateTime)) |  |
| [DateTimeSpan(DateTime start, DateTimeSpanType spanType, int step)](DateTimeSpan_DateTimeSpan(DateTime,DateTimeSpanType,Int32)) |  |

| Static Constructor | Description |
| --- | --- |
| [DateTimeSpan()](DateTimeSpan_DateTimeSpan()) |  |

| Method | Description |
| --- | --- |
| [get_Start()](DateTimeSpan_get_Start()) |  |
| [get_End()](DateTimeSpan_get_End()) |  |
| [get_SpanType()](DateTimeSpan_get_SpanType()) |  |
| [set_SpanType(DateTimeSpanType value)](DateTimeSpan_set_SpanType(DateTimeSpanType)) |  |
| [get_Step()](DateTimeSpan_get_Step()) |  |
| [set_Step(int value)](DateTimeSpan_set_Step(Int32)) |  |
| [GetEnumerator(DateTimeSpanType spanType, int step)](DateTimeSpan_GetEnumerator(DateTimeSpanType,Int32)) | Returns an enumerator to iterate over the sequence of &lt;see cref=&quot;T:System.DateTime&quot; /&gt; |
| [GetEnumerator()](DateTimeSpan_GetEnumerator()) |  |
| [System.Collections.IEnumerable.GetEnumerator()](DateTimeSpan_System.Collections.IEnumerable.GetEnumerator()) |  |
| [Deconstruct(out DateTime start, out DateTime end)](DateTimeSpan_Deconstruct(DateTime,DateTime)) |  |
| [ToString()](Object_ToString()) |  |
| [Equals(object obj)](Object_Equals(Object)) |  |
| [GetHashCode()](Object_GetHashCode()) |  |
| [GetType()](Object_GetType()) |  |
| [Finalize()](Object_Finalize()) |  |
| [MemberwiseClone()](Object_MemberwiseClone()) |  |

