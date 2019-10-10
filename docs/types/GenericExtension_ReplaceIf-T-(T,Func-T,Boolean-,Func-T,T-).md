

[back](/IronSphere.Extensions/types/GenericExtension)

# GenericExtension.ReplaceIf&lt;T&gt;(this T this, Func&lt;T, bool&gt; expression, Func&lt;T, T&gt; output) Method

> Assembly: IronSphere.Extensions

```csharp
public static T ReplaceIf<T>(this T this, Func<T, bool> expression, Func<T, T> output);
```

Replaces an object with another value of the same type, if the expression returns true

 