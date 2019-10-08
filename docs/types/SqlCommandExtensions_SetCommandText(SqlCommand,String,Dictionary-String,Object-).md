

# SetCommandText

> Assembly: IronSphere.Extensions

```csharp
public static DbCommand SetCommandText(this SqlCommand this, String command, Dictionary<String,Object> parameters)
```

Sets the SqlCommands command-text and adds parameters

```csharp
Dictionary<string, object> paramsDictionary = new Dictionary<string, object>(){
    { "user", "admin" }
};
SqlCommand command = new SqlCommand();
command.SetCommandText("select * from user where userId = @user", paramsDictionary);
``` 