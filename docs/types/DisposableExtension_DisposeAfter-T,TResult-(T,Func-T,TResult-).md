

# DisposeAfter

> Assembly: IronSphere.Extensions



```


public static TResultDisposeAfter<T, TResult>(T instance, Func<T,TResult> actionToInvoke)
    where T: IDisposable;
```