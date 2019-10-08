

# CutAt

> Assembly: IronSphere.Extensions

```csharp
public static String CutAt(this String this, Int32 position, String endConcat, Boolean waitForWhitespace = false)
```

Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position.

 