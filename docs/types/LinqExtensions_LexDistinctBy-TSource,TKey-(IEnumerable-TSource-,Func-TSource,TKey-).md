

[back](/IronSphere.Extensions/types/LinqExtensions)

# LinqExtensions.LexDistinctBy&lt;TSource,TKey&gt;(this IEnumerable&lt;TSource&gt; source, Func&lt;TSource, TKey&gt; groupingSelector) Method

> Assembly: IronSphere.Extensions

```csharp
IEnumerable<TSource> LexDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> groupingSelector);
```

Returns distinct elements from a sequence by using a selected property to compare values.

 