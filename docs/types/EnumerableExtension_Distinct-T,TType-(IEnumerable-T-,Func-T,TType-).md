

[back](/IronSphere.Extensions/types/EnumerableExtension)

# Distinct

> Assembly: IronSphere.Extensions

```csharp
public static IEnumerable<T> Distinct<T, TType>(this IEnumerable<T> this, Func<T,TType> expression);
```

Iterates through a list of items and yields all elements but not duplicated.

 