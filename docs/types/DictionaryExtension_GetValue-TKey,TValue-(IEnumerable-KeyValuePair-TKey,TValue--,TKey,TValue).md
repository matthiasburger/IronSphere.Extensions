

[back](/IronSphere.Extensions/types/DictionaryExtension)

# DictionaryExtension.GetValue&lt;TKey,TValue&gt;(this IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; this, TKey key, TValue fallback = default) Method

> Assembly: IronSphere.Extensions

```csharp
public static TValue GetValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> this, TKey key, TValue fallback = default);
```

Searches for a key in a generic key-value-sequence and returns its value if it exists.

 