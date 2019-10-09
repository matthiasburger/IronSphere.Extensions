

[back](/IronSphere.Extensions/types/CollectionExtension)

# CollectionExtension.AddMissing Method

> Assembly: IronSphere.Extensions

```csharp
ICollection<T> AddMissing<T, TSelectorType>(this ICollection<T> this, IEnumerable<T> elementsToAdd, Func<T, TSelectorType> selector);
```

adds all elements in a parametrized list into an existing collection if the collection already contains an element it skips it

 