[back](/IronSphere.Extensions/types)

# StringExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll



```csharp
public static class StringExtension : Object
```
Inheritance: Object



Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




| Static Method | Description |
| --- | --- |
| [GetBytes(this String this, this Encoding encoding = null)](StringExtension_GetBytes(String,Encoding)) | Encodes all the characters in the specified string into a sequence of bytes |
| [IsNullOrEmpty(this String this)](StringExtension_IsNullOrEmpty(String)) | Indicates whether the specified string is null or an empty string (&quot;&quot;). |
| [IsNullOrWhiteSpace(this String this)](StringExtension_IsNullOrWhiteSpace(String)) | Indicates whether a specified string is null, empty, or consists only of white-space characters. |
| [ValueIfNullOrEmpty(this String this, this String defaultValue)](StringExtension_ValueIfNullOrEmpty(String,String)) |  |
| [ValueIfNullOrWhiteSpace(this String this, this String defaultValue)](StringExtension_ValueIfNullOrWhiteSpace(String,String)) |  |
| [Join&lt;T&gt;(this String this, this IEnumerable&lt;T&gt; elements)](StringExtension_Join-T-(String,IEnumerable-T-)) | Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member. |
| [StartsWithAny(this String this, this String[] parameter)](StringExtension_StartsWithAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [EndsWithAny(this String this, this String[] parameter)](StringExtension_EndsWithAny(String,String[])) | Indicates whether a specified string ends with any parametrized string |
| [ContainsAny(this String this, this String[] parameter)](StringExtension_ContainsAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [Split(this String this, this Int32 position)](StringExtension_Split(String,Int32)) | Splits a string after a specified position |
| [CutAt(this String this, this Int32 position, this String endConcat, this Boolean waitForWhitespace = false)](StringExtension_CutAt(String,Int32,String,Boolean)) | Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position. |
| [ToIntOrNull(this String this)](StringExtension_ToIntOrNull(String)) | Parses a string to its int representation |
| [RemoveDiacritics(this String this)](StringExtension_RemoveDiacritics(String)) | Removes all diacritics in a string |
| [UpholsterLeft(this String this, this Int32 count, this Char character = &#39; &#39;)](StringExtension_UpholsterLeft(String,Int32,Char)) | upholsters a string on the left with a specific character |
| [UpholsterRight(this String this, this Int32 count, this Char character = &#39; &#39;)](StringExtension_UpholsterRight(String,Int32,Char)) | upholsters a string on the right with a specific character |
| [Upholster(this String this, this Int32 count, this Char character = &#39; &#39;)](StringExtension_Upholster(String,Int32,Char)) | upholsters a string on the left and right with a specific character |
| [Format(this String this, this Object anonymousObject)](StringExtension_Format(String,Object)) | formats a string with values in an anonymous object |
| [Format(this String this, this IDictionary&lt;String,Object&gt; values)](StringExtension_Format(String,IDictionary-String,Object-)) | formats a string with values in a dictionary |
| [_stringFormat(this String this, this IDictionary&lt;String,Object&gt; values)](StringExtension__stringFormat(String,IDictionary-String,Object-)) |  |
