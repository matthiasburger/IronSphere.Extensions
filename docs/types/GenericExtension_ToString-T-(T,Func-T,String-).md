﻿

[back](/IronSphere.Extensions/types/GenericExtension)

# GenericExtension.ToString&lt;T&gt;(this T this, Func&lt;T, string&gt; resultString) Method

> Assembly: IronSphere.Extensions

```csharp
public static string ToString<T>(this T this, Func<T, string> resultString);
```

String representation of any object

```csharp
new Test{ p = 1, q = 2 }.ToString(s => $"{s.p + s.q}") == "3";
``` 