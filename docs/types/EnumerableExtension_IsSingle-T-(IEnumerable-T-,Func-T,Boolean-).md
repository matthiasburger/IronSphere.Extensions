

[back](/IronSphere.Extensions/EnumerableExtension)

# IsSingle

> Assembly: IronSphere.Extensions

```csharp
public static Boolean IsSingle<T>(this IEnumerable<T> this, Func<T,Boolean> predicate);
```

Determines if an enumeration contains exactly one element

```csharp
bool isSingleUser = Context.Users.IsSingle(w => w.Name == "test");
``` 