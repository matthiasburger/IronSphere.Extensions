

[back](/IronSphere.Extensions/types/DisposableExtension)

# DisposableExtension.DisposeAfter Method

> Assembly: IronSphere.Extensions

```csharp
TResult DisposeAfter<T, TResult>(this T instance, Func<T, TResult> actionToInvoke)
    where T: IDisposable;
```

wrapper for disposing disposes after execution

 