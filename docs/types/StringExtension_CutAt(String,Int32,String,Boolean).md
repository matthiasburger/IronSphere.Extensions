

[back](/IronSphere.Extensions/types/StringExtension)

# StringExtension.CutAt(this string this, int position, string endConcat, bool waitForWhitespace = false) Method

> Assembly: IronSphere.Extensions

```csharp
string CutAt(this string this, int position, string endConcat, bool waitForWhitespace = false)
```

Cuts a string at a specified position. The string can be at the end concatenated with a suffix. By specifying waitForWhitespace the string will be cut after the next whitespace after position.

 