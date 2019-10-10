

[back](/IronSphere.Extensions/types/SqlCommandExtensions)

# SqlCommandExtensions.SetCommandText(this SqlCommand this, string command, object parameters) Method

> Assembly: IronSphere.Extensions

```csharp
public static DbCommand SetCommandText(this SqlCommand this, string command, object parameters)
```

Sets the SqlCommands command-text and adds parameters

```csharp
SqlCommand command = new SqlCommand();
command.SetCommandText("select * from user where userId = @user", new{user="admin"});
``` 