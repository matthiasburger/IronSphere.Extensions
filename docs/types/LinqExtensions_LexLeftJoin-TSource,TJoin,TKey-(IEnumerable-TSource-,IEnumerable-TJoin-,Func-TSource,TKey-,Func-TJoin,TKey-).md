

[back](/IronSphere.Extensions/types/LinqExtensions)

# LinqExtensions.LexLeftJoin&lt;TSource,TJoin,TKey&gt;(this IEnumerable&lt;TSource&gt; source, IEnumerable&lt;TJoin&gt; inner, Func&lt;TSource, TKey&gt; outerKeySelector, Func&lt;TJoin, TKey&gt; innerKeySelector) Method

> Assembly: IronSphere.Extensions

```csharp
IEnumerable<IJoinSet<TSource, TJoin>> LexLeftJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource, TKey> outerKeySelector, Func<TJoin, TKey> innerKeySelector);
```

Performs a left join over two enumerable sequences

 