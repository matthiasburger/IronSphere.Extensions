[back](/IronSphere.Extensions/types)

# DictionaryExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for &lt;see cref=&quot;T:System.Collections.Generic.Dictionary`2&quot; /&gt;

```csharp
public static class DictionaryExtension : Object
```
    Inheritance: Object


    
    Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




    | Static Method | Description |
    | --- | --- |
| [GetValue&lt;TKey,TValue&gt;(this Dictionary&lt;TKey, TValue&gt; this, TKey key, TValue fallback = default)](DictionaryExtension_GetValue-TKey,TValue-(Dictionary-TKey,TValue-,TKey,TValue)) | Searches for a key in a dictionary and returns its value if it exists. |
| [GetValue&lt;TValue&gt;(this NameValueCollection this, string key, TValue fallback = default)](DictionaryExtension_GetValue-TValue-(NameValueCollection,String,TValue)) | Searches for a key in a name-value-collection and returns its value if it exists. |
| [GetValue&lt;TKey,TValue&gt;(this IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; this, TKey key, TValue fallback = default)](DictionaryExtension_GetValue-TKey,TValue-(IEnumerable-KeyValuePair-TKey,TValue--,TKey,TValue)) | Searches for a key in a generic key-value-sequence and returns its value if it exists. |
| [AddOrUpdate&lt;TKey,TValue&gt;(this IDictionary&lt;TKey, TValue&gt; this, TKey key, TValue value)](DictionaryExtension_AddOrUpdate-TKey,TValue-(IDictionary-TKey,TValue-,TKey,TValue)) |  |
| [GetOrCreate&lt;TKey,TValue&gt;(this IDictionary&lt;TKey, TValue&gt; this, TKey key, Func&lt;TKey, TValue&gt; function)](DictionaryExtension_GetOrCreate-TKey,TValue-(IDictionary-TKey,TValue-,TKey,Func-TKey,TValue-)) |  |
