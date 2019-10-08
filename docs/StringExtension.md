


# StringExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll



```csharp
public static class StringExtension : Object
```

    Inheritance Object


    
    Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




    | Static Method | Description |
    | --- | --- |
| [GetBytes(String this, Encoding encoding = null)](StringExtension.GetBytes(String,Encoding)) | Encodes all the characters in the specified string into a sequence of bytes |
| [IsNullOrEmpty(String this)](StringExtension.IsNullOrEmpty(String)) | Indicates whether the specified string is null or an empty string (&quot;&quot;). |
| [IsNullOrWhiteSpace(String this)](StringExtension.IsNullOrWhiteSpace(String)) | Indicates whether a specified string is null, empty, or consists only of white-space characters. |
| [ValueIfNullOrEmpty(String this, String defaultValue)](StringExtension.ValueIfNullOrEmpty(String,String)) |  |
| [ValueIfNullOrWhiteSpace(String this, String defaultValue)](StringExtension.ValueIfNullOrWhiteSpace(String,String)) |  |
| [Join&lt;T&gt;(String this, IEnumerable&lt;T&gt; elements)](StringExtension.Join-T-(String,IEnumerable-T-)) | Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member. |
| [StartsWithAny(String this, String[] parameter)](StringExtension.StartsWithAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [EndsWithAny(String this, String[] parameter)](StringExtension.EndsWithAny(String,String[])) | Indicates whether a specified string ends with any parametrized string |
| [ContainsAny(String this, String[] parameter)](StringExtension.ContainsAny(String,String[])) | Indicates whether a specified string starts with any parametrized string |
| [Split(String this, Int32 position)](StringExtension.Split(String,Int32)) | Splits a string after a specified position |
| [CutAt(String this, Int32 position, String endConcat, Boolean waitForWhitespace = false)](StringExtension.CutAt(String,Int32,String,Boolean)) | Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position. |
| [ToIntOrNull(String this)](StringExtension.ToIntOrNull(String)) | Parses a string to its int representation |
| [RemoveDiacritics(String this)](StringExtension.RemoveDiacritics(String)) | Removes all diacritics in a string |
| [UpholsterLeft(String this, Int32 count, Char character = &#39; &#39;)](StringExtension.UpholsterLeft(String,Int32,Char)) | upholsters a string on the left with a specific character |
| [UpholsterRight(String this, Int32 count, Char character = &#39; &#39;)](StringExtension.UpholsterRight(String,Int32,Char)) | upholsters a string on the right with a specific character |
| [Upholster(String this, Int32 count, Char character = &#39; &#39;)](StringExtension.Upholster(String,Int32,Char)) | upholsters a string on the left and right with a specific character |
| [Format(String this, Object anonymousObject)](StringExtension.Format(String,Object)) | formats a string with values in an anonymous object |
| [Format(String this, IDictionary&lt;String,Object&gt; values)](StringExtension.Format(String,IDictionary-String,Object-)) | formats a string with values in a dictionary |
| [_stringFormat(String this, IDictionary&lt;String,Object&gt; values)](StringExtension._stringFormat(String,IDictionary-String,Object-)) |  |
