[back](/IronSphere.Extensions/types)

# StringExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for &lt;see cref=&quot;T:System.String&quot; /&gt;

```csharp
public static class StringExtension : Object
```
Inheritance: Object



Attributes:

* System.Runtime.CompilerServices.ExtensionAttribute



| Static Method | Description |
| --- | --- |
| [GetBytes(this string this, Encoding encoding = null)](StringExtension_GetBytes(String,Encoding)) | Encodes all the characters in the specified string into a sequence of bytes |
| [IsNullOrEmpty(this string this)](StringExtension_IsNullOrEmpty(String)) | Indicates whether the specified string is null or an empty string (&quot;&quot;). |
| [IsNullOrWhiteSpace(this string this)](StringExtension_IsNullOrWhiteSpace(String)) | Indicates whether a specified string is null, empty, or consists only of white-space characters. |
| [ValueIfNullOrEmpty(this string this, string defaultValue)](StringExtension_ValueIfNullOrEmpty(String,String)) |  |
| [ValueIfNullOrWhiteSpace(this string this, string defaultValue)](StringExtension_ValueIfNullOrWhiteSpace(String,String)) |  |
| [Join&lt;T&gt;(this string this, IEnumerable&lt;T&gt; elements)](StringExtension_Join-T-(String,IEnumerable-T-)) | Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member. |
| [StartsWithAny(this string this, string[] parameter)](StringExtension_StartsWithAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [EndsWithAny(this string this, string[] parameter)](StringExtension_EndsWithAny(String,String[])) | Indicates whether a specified string ends with any parametrized string |
| [ContainsAny(this string this, string[] parameter)](StringExtension_ContainsAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [Split(this string this, int position)](StringExtension_Split(String,Int32)) | Splits a string after a specified position |
| [CutAt(this string this, int position, string endConcat, bool waitForWhitespace = false)](StringExtension_CutAt(String,Int32,String,Boolean)) | Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position. |
| [ToIntOrNull(this string this)](StringExtension_ToIntOrNull(String)) | Parses a string to its int representation |
| [RemoveDiacritics(this string this)](StringExtension_RemoveDiacritics(String)) | Removes all diacritics in a string |
| [UpholsterLeft(this string this, int count, char character = &#39; &#39;)](StringExtension_UpholsterLeft(String,Int32,Char)) | upholsters a string on the left with a specific character |
| [UpholsterRight(this string this, int count, char character = &#39; &#39;)](StringExtension_UpholsterRight(String,Int32,Char)) | upholsters a string on the right with a specific character |
| [Upholster(this string this, int count, char character = &#39; &#39;)](StringExtension_Upholster(String,Int32,Char)) | upholsters a string on the left and right with a specific character |
| [Format(this string this, object anonymousObject)](StringExtension_Format(String,Object)) | formats a string with values in an anonymous object |
| [Format(this string this, IDictionary&lt;string, object&gt; values)](StringExtension_Format(String,IDictionary-String,Object-)) | formats a string with values in a dictionary |
| [_stringFormat(this string this, IDictionary&lt;string, object&gt; values)](StringExtension__stringFormat(String,IDictionary-String,Object-)) |  |
