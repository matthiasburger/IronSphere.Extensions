# GenericExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll



```csharp
public static class GenericExtension : Object
```
Inheritance: Object



Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




| Static Method | Description |
| --- | --- |
| [In&lt;T&gt;(T this, IEnumerable&lt;T&gt; listOfItems)](GenericExtension.In-T-(T,IEnumerable-T-)) | Determines if an object is contained in a list |
| [In&lt;T&gt;(T this, T[] listOfItems)](GenericExtension.In-T-(T,T[])) |  |
| [NotIn&lt;T&gt;(T this, T[] listOfItems)](GenericExtension.NotIn-T-(T,T[])) |  |
| [ReplaceIf&lt;T&gt;(T this, Func&lt;T,Boolean&gt; expression, T output)](GenericExtension.ReplaceIf-T-(T,Func-T,Boolean-,T)) | Replaces an object with another value of the same type, if the expression returns true |
| [ReplaceIf&lt;T&gt;(T this, Func&lt;T,Boolean&gt; expression, Func&lt;T,T&gt; output)](GenericExtension.ReplaceIf-T-(T,Func-T,Boolean-,Func-T,T-)) | Replaces an object with another value of the same type, if the expression returns true |
| [ToString&lt;T&gt;(T this, Func&lt;T,String&gt; resultString)](GenericExtension.ToString-T-(T,Func-T,String-)) | String representation of any object |
