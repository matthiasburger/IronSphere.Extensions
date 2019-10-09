

[back](/IronSphere.Extensions/types/GenericExtension

# ToString

> Assembly: IronSphere.Extensions

```csharp
string ToString<T>(this T this, Func<T, string> resultString);
```

String representation of any object

```csharp
new Test{ p = 1, q = 2 }.ToString(s => $"{s.p + s.q}") == "3";
``` 