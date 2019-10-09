

[back](/IronSphere.Extensions/types/DictionaryExtension)

# DictionaryExtension.GetValue Method

> Assembly: IronSphere.Extensions

```csharp
TValue GetValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> this, TKey key, TValue fallback = default);
```

Searches for a key in a generic key-value-sequence and returns its value if it exists.

 