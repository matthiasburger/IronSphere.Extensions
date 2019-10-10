

[back](/IronSphere.Extensions/types/DisposableExtension)

# DisposableExtension.DisposeAfter&lt;T,TResult&gt;(this T instance, Func&lt;T, TResult&gt; actionToInvoke) Method

> Assembly: IronSphere.Extensions

```csharp
public static TResult DisposeAfter<T, TResult>(this T instance, Func<T, TResult> actionToInvoke)
    where T: IDisposable;
```

wrapper for disposing disposes after execution

 