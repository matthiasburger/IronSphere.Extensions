

[back](/IronSphere.Extensions/types/TypeExtension)

# TypeExtension.GetNonGenericTypeName Method

> Assembly: IronSphere.Extensions

```csharp
string GetNonGenericTypeName(this Type this)
```

Gets the non-generic name for a type

```csharp
string x = typeof(Dictionary<int, string>).GetNonGenericTypeName();
bool isTrue = x == "System.Collections.Generic.Dictionary";
``` 