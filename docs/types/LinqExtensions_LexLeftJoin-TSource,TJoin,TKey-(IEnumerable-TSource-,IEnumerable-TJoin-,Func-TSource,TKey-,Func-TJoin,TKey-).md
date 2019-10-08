

# LexLeftJoin

> Assembly: IronSphere.Extensions

```csharp
public static IEnumerable<IJoinSet<TSource,TJoin>> LexLeftJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource,TKey> outerKeySelector, Func<TJoin,TKey> innerKeySelector);
```

Performs a left join over two enumerable sequences

 