

# ReplaceIf

> Assembly: IronSphere.Extensions

```csharp
public static T ReplaceIf<T>(this T this, Func<T,Boolean> expression, Func<T,T> output);
```

Replaces an object with another value of the same type, if the expression returns true

 