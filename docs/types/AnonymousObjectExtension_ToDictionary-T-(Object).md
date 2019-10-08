

# ToDictionary

> Assembly: IronSphere.Extensions

```csharp
public static IDictionary<String,T> ToDictionary<T>(this Object source);
```

Creates a dictionary from an anonymous type where the properties names are the keys and their values are the values

```csharp
// use it like:
var source = new { a = 3, c = 7 };
IDictionary<string, int> generatedDictionary = source.ToDictionary<int>();
``` 