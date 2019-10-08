

# LexLeftJoin

> Assembly: IronSphere.Extensions



```


public static IEnumerable<IJoinSet<TSource,TJoin>> LexLeftJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource,TKey> outerKeySelector, Func<TJoin,TKey> innerKeySelector);
```