# DictionaryExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll



```csharp
public static class DictionaryExtension : Object
```
Inheritance: Object



Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




| Static Method | Description |
| --- | --- |
| [GetValue&lt;TKey,TValue&gt;(Dictionary&lt;TKey,TValue&gt; this, TKey key, TValue fallback = default)](DictionaryExtension.GetValue-TKey,TValue-(Dictionary-TKey,TValue-,TKey,TValue)) | Searches for a key in a dictionary and returns its value if it exists. |
| [GetValue&lt;TValue&gt;(NameValueCollection this, String key, TValue fallback = default)](DictionaryExtension.GetValue-TValue-(NameValueCollection,String,TValue)) | Searches for a key in a name-value-collection and returns its value if it exists. |
| [GetValue&lt;TKey,TValue&gt;(IEnumerable&lt;KeyValuePair&lt;TKey,TValue&gt;&gt; this, TKey key, TValue fallback = default)](DictionaryExtension.GetValue-TKey,TValue-(IEnumerable-KeyValuePair-TKey,TValue--,TKey,TValue)) | Searches for a key in a generic key-value-sequence and returns its value if it exists. |
| [AddOrUpdate&lt;TKey,TValue&gt;(IDictionary&lt;TKey,TValue&gt; this, TKey key, TValue value)](DictionaryExtension.AddOrUpdate-TKey,TValue-(IDictionary-TKey,TValue-,TKey,TValue)) |  |
| [GetOrCreate&lt;TKey,TValue&gt;(IDictionary&lt;TKey,TValue&gt; this, TKey key, Func&lt;TKey,TValue&gt; function)](DictionaryExtension.GetOrCreate-TKey,TValue-(IDictionary-TKey,TValue-,TKey,Func-TKey,TValue-)) |  |
