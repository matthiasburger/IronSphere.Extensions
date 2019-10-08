

# LexLeftJoin

> Assembly: IronSphere.Extensions



```


public static IEnumerable<IJoinSet<TSource,TJoin>> LexLeftJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, this IEnumerable<TJoin> inner, this Func<TSource,TKey> outerKeySelector, this Func<TJoin,TKey> innerKeySelector);
```