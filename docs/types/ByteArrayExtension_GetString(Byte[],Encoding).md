

[back](/IronSphere.Extensions/types/ByteArrayExtension)

# GetString

> Assembly: IronSphere.Extensions

```csharp
public static string GetString(this byte[] bytes, Encoding encoding = null)
```

Decodes all bytes in a specified array into a string.

```csharp
const string originalStringValue = "my original value with ä ö and ü";
byte[] originalUtf8Bytes = originalStringValue.GetBytes();
string itsString = originalUtf8Bytes.GetString();
``` 