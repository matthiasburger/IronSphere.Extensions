

[back](/IronSphere.Extensions/types/SqlCommandExtensions)

# SqlCommandExtensions.SetCommandText Method

> Assembly: IronSphere.Extensions

```csharp
DbCommand SetCommandText(this SqlCommand this, string command, Dictionary<string, object> parameters)
```

Sets the SqlCommands command-text and adds parameters

```csharp
Dictionary<string, object> paramsDictionary = new Dictionary<string, object>(){
    { "user", "admin" }
};
SqlCommand command = new SqlCommand();
command.SetCommandText("select * from user where userId = @user", paramsDictionary);
``` 