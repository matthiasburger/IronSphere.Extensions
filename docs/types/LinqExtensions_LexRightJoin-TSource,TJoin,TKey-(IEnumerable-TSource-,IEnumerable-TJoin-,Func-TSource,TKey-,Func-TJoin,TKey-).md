

[back](/IronSphere.Extensions/types/LinqExtensions)

# LexRightJoin

> Assembly: IronSphere.Extensions

```csharp
public static IEnumerable<IJoinSet<TJoin, TSource>> LexRightJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource, TKey> outerKeySelector, Func<TJoin, TKey> innerKeySelector);
```

Performs a right join over two enumerable sequences

 