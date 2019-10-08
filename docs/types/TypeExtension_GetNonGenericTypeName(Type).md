

# GetNonGenericTypeName

> Assembly: IronSphere.Extensions

```csharp
public static String GetNonGenericTypeName(this Type this)
```

Gets the non-generic name for a type

```csharp
string x = typeof(Dictionary<int, string>).GetNonGenericTypeName();
bool isTrue = x == "System.Collections.Generic.Dictionary";
``` 