

[back](/IronSphere.Extensions/types/CollectionExtension)

# CollectionExtension.AddMissing&lt;T,TSelectorType&gt;(this ICollection&lt;T&gt; this, IEnumerable&lt;T&gt; elementsToAdd, Func&lt;T, TSelectorType&gt; selector) Method

> Assembly: IronSphere.Extensions

```csharp
public static ICollection<T> AddMissing<T, TSelectorType>(this ICollection<T> this, IEnumerable<T> elementsToAdd, Func<T, TSelectorType> selector);
```

adds all elements in a parametrized list into an existing collection if the collection already contains an element it skips it

 