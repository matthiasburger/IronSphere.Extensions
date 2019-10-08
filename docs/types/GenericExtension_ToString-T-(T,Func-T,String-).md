

# ToString

> Assembly: IronSphere.Extensions

```csharp
public static String ToString<T>(this T this, Func<T,String> resultString);
```

String representation of any object

```csharp
            new Test{ p = 1, q = 2 }.ToString(s => $"{s.p + s.q}") == "3";
            
```