

[back](/IronSphere.Extensions/types/EnumerableExtension)

# EnumerableExtension.IsSingle&lt;T&gt;(this IEnumerable&lt;T&gt; this) Method

> Assembly: IronSphere.Extensions

```csharp
bool IsSingle<T>(this IEnumerable<T> this);
```

Determines if an enumeration contains exactly one element

```csharp
bool isSingleUser = Context.Users.Where(w => w.Name == "test").IsSingle();
``` 