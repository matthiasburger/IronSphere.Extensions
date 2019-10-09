

[back](/IronSphere.Extensions/types/LinqExtensions)

# LinqExtensions.LexLeftJoin Method

> Assembly: IronSphere.Extensions

```csharp
IEnumerable<IJoinSet<TSource, TJoin>> LexLeftJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource, TKey> outerKeySelector, Func<TJoin, TKey> innerKeySelector);
```

Performs a left join over two enumerable sequences

 