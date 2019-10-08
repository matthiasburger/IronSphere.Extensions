

# IsNullOrEmpty

> Assembly: IronSphere.Extensions

```csharp
public static Boolean IsNullOrEmpty<T>(this IEnumerable<T> this);
```

Determines whether an &lt;see cref=&quot;T:System.Collections.Generic.IEnumerable`1&quot; /&gt; is either null or doesn&#39;t contain any elements

```csharp
bool isNullOrEmpty = GetAListOfItemsFromSomewhere().IsNullOrEmpty();
``` 