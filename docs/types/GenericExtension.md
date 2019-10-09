[back](/IronSphere.Extensions/types)

# GenericExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for a generic type T

```csharp
public static class GenericExtension : Object
```
Inheritance: Object



Attributes:

* System.Runtime.CompilerServices.ExtensionAttribute



| Static Method | Description |
| --- | --- |
| [In&lt;T&gt;(this T this, IEnumerable&lt;T&gt; listOfItems)](GenericExtension_In-T-(T,IEnumerable-T-)) | Determines if an object is contained in a list |
| [In&lt;T&gt;(this T this, T[] listOfItems)](GenericExtension_In-T-(T,T[])) |  |
| [NotIn&lt;T&gt;(this T this, T[] listOfItems)](GenericExtension_NotIn-T-(T,T[])) |  |
| [ReplaceIf&lt;T&gt;(this T this, Func&lt;T, bool&gt; expression, T output)](GenericExtension_ReplaceIf-T-(T,Func-T,Boolean-,T)) | Replaces an object with another value of the same type, if the expression returns true |
| [ReplaceIf&lt;T&gt;(this T this, Func&lt;T, bool&gt; expression, Func&lt;T, T&gt; output)](GenericExtension_ReplaceIf-T-(T,Func-T,Boolean-,Func-T,T-)) | Replaces an object with another value of the same type, if the expression returns true |
| [ToString&lt;T&gt;(this T this, Func&lt;T, string&gt; resultString)](GenericExtension_ToString-T-(T,Func-T,String-)) | String representation of any object |
