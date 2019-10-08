

[back](/IronSphere.Extensions/types/EnumerableExtension)

# IsSingle

> Assembly: IronSphere.Extensions

```csharp
public static bool IsSingle<T>(this IEnumerable<T> this, Func<T, bool> predicate);
```

Determines if an enumeration contains exactly one element

```csharp
bool isSingleUser = Context.Users.IsSingle(w => w.Name == "test");
``` 