﻿

[back](/IronSphere.Extensions/types/LinqExtensions)

# LinqExtensions.LexRightJoin&lt;TSource,TJoin,TKey&gt;(this IEnumerable&lt;TSource&gt; source, IEnumerable&lt;TJoin&gt; inner, Func&lt;TSource, TKey&gt; outerKeySelector, Func&lt;TJoin, TKey&gt; innerKeySelector) Method

> Assembly: IronSphere.Extensions

```csharp
public static IEnumerable<IJoinSet<TJoin, TSource>> LexRightJoin<TSource, TJoin, TKey>(this IEnumerable<TSource> source, IEnumerable<TJoin> inner, Func<TSource, TKey> outerKeySelector, Func<TJoin, TKey> innerKeySelector);
```

Performs a right join over two enumerable sequences

 