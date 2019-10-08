

# SetCommandText

> Assembly: IronSphere.Extensions

```csharp
public static DbCommand SetCommandText(this SqlCommand this, String command, Object parameters)
```

Sets the SqlCommands command-text and adds parameters

```csharp
<code><![CDATA[ SqlCommand command = new SqlCommand(); command.SetCommandText("select * from user where userId = @user", new{user="admin"}); ]]></code>
``` 