

[back](/IronSphere.Extensions/types/DisposableExtension)

# DisposeAfter

> Assembly: IronSphere.Extensions

```csharp
public static TResult DisposeAfter<T, TResult>(this T instance, Func<T,TResult> actionToInvoke)
    where T: IDisposable;
```

wrapper for disposing disposes after execution

 