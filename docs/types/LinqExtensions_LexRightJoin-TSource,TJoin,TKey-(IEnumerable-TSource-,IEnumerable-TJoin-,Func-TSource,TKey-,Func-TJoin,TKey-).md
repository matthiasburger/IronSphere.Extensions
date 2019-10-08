

# LexRightJoin

> Assembly: IronSphere.Extensions



```


public static IEnumerable<IJoinSet<TJoin,TSource>> LexRightJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource,TKey> outerKeySelector, Func<TJoin,TKey> innerKeySelector);
```