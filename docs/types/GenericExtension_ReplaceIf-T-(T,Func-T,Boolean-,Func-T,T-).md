

[back](/IronSphere.Extensions/types/GenericExtension)

# GenericExtension.ReplaceIf Method

> Assembly: IronSphere.Extensions

```csharp
T ReplaceIf<T>(this T this, Func<T, bool> expression, Func<T, T> output);
```

Replaces an object with another value of the same type, if the expression returns true

 