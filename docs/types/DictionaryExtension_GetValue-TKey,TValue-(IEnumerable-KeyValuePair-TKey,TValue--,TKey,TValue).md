

[back](/IronSphere.Extensions/types/DictionaryExtension)

# GetValue

> Assembly: IronSphere.Extensions

```csharp
public static TValue GetValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> this, TKey key, TValue fallback = default);
```

Searches for a key in a generic key-value-sequence and returns its value if it exists.

 