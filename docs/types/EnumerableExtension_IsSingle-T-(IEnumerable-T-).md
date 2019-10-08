

# IsSingle

> Assembly: IronSphere.Extensions

```csharp
public static Boolean IsSingle<T>(this IEnumerable<T> this);
```

Determines if an enumeration contains exactly one element

```csharp
            bool isSingleUser = Context.Users.Where(w => w.Name == "test").IsSingle();
            
```