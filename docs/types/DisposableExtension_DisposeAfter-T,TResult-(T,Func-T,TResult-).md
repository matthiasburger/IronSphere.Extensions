

# DisposeAfter

> Assembly: IronSphere.Extensions



```


public static TResult DisposeAfter<T, TResult>(this T instance, Func<T,TResult> actionToInvoke)
    where T: IDisposable;
```