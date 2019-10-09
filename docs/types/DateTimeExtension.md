[back](/IronSphere.Extensions/types)

# DateTimeExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for &lt;see cref=&quot;T:System.DateTime&quot; /&gt;

```csharp
public static class DateTimeExtension : Object
```
    Inheritance: Object


    
    Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute


    | Static Constructor | Description |
    | --- | --- |
| [DateTimeExtension()](DateTimeExtension_DateTimeExtension()) |  |


    | Static Method | Description |
    | --- | --- |
| [GetFirstOfWeek(this DateTime this, DayOfWeek startOfWeek = DayOfWeek.Monday)](DateTimeExtension_GetFirstOfWeek(DateTime,DayOfWeek)) | Calculates the first day of a week. |
| [GetLastOfWeek(this DateTime this, DayOfWeek startOfWeek = DayOfWeek.Monday)](DateTimeExtension_GetLastOfWeek(DateTime,DayOfWeek)) | Calculates the last day of a week. |
| [GetFirstOfMonth(this DateTime this)](DateTimeExtension_GetFirstOfMonth(DateTime)) | Calculates the first day of a month. |
| [GetLastOfMonth(this DateTime this)](DateTimeExtension_GetLastOfMonth(DateTime)) | Calculates the last day of a month. |
| [IsLeapYear(this DateTime this)](DateTimeExtension_IsLeapYear(DateTime)) | Determines whether the year of the given date is a leap year |
| [Between(this DateTime this, DateTime lower, DateTime higher)](DateTimeExtension_Between(DateTime,DateTime,DateTime)) | Determines, if a convertible object is between two objects of the same type |
| [GetAge(this DateTime this)](DateTimeExtension_GetAge(DateTime)) | Calculates the age (years) from a date. |
| [GetWeekOfYear(this DateTime dateTime, CultureInfo cultureInfo = null, WeekOfYearStandard weekOfYearStandard = WeekOfYearStandard.Iso8601)](DateTimeExtension_GetWeekOfYear(DateTime,CultureInfo,WeekOfYearStandard)) | Gets the calendar-week of a date dependent to a culture with ISO 8601 |
| [GetWeekOfYearIso8601(this DateTime dateTime, CultureInfo cultureInfo)](DateTimeExtension_GetWeekOfYearIso8601(DateTime,CultureInfo)) |  |
| [GetWeekOfYearNetStandard(this DateTime dateTime, CultureInfo cultureInfo)](DateTimeExtension_GetWeekOfYearNetStandard(DateTime,CultureInfo)) |  |
| [IsWeekend(this DateTime this)](DateTimeExtension_IsWeekend(DateTime)) | determines whether a date is in weekend |
