

# DisposeAfter

> Assembly: IronSphere.Extensions



```


public static TResult DisposeAfter<T, TResult>(this T instance, this Func<T,TResult> actionToInvoke)
    where T: IDisposable;
```