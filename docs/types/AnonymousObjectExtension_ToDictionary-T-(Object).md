﻿

[back](/IronSphere.Extensions/types/AnonymousObjectExtension)

# AnonymousObjectExtension.ToDictionary&lt;T&gt;(this object source) Method

> Assembly: IronSphere.Extensions

```csharp
public static IDictionary<string, T> ToDictionary<T>(this object source);
```

Creates a dictionary from an anonymous type where the properties names are the keys and their values are the values

```csharp
// use it like:
var source = new { a = 3, c = 7 };
IDictionary<string, int> generatedDictionary = source.ToDictionary<int>();
``` 