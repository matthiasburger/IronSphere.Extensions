

[back](/IronSphere.Extensions/types/EnumerableExtension)

# EnumerableExtension.IsSingle Method

> Assembly: IronSphere.Extensions

```csharp
bool IsSingle<T>(this IEnumerable<T> this, Func<T, bool> predicate);
```

Determines if an enumeration contains exactly one element

```csharp
bool isSingleUser = Context.Users.IsSingle(w => w.Name == "test");
``` 