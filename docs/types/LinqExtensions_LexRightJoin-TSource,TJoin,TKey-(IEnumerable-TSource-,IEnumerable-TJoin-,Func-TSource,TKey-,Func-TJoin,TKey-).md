

# LexRightJoin

> Assembly: IronSphere.Extensions



```


public static IEnumerable<IJoinSet<TJoin,TSource>> LexRightJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, this IEnumerable<TJoin> inner, this Func<TSource,TKey> outerKeySelector, this Func<TJoin,TKey> innerKeySelector);
```