

[back](/IronSphere.Extensions/types/SqlCommandExtensions)

# SetCommandText

> Assembly: IronSphere.Extensions

```csharp
DbCommand SetCommandText(this SqlCommand this, string command, object parameters)
```

Sets the SqlCommands command-text and adds parameters

```csharp
SqlCommand command = new SqlCommand();
command.SetCommandText("select * from user where userId = @user", new{user="admin"});
``` 