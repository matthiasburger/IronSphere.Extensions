

[back](/IronSphere.Extensions/types/LinqExtensions

# LexDistinctBy

> Assembly: IronSphere.Extensions

```csharp
IEnumerable<TSource> LexDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> groupingSelector);
```

Returns distinct elements from a sequence by using a selected property to compare values.

 