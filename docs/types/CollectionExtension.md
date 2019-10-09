[back](/IronSphere.Extensions/types)

# CollectionExtension

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for &lt;see cref=&quot;T:System.Collections.Generic.ICollection`1&quot; /&gt;

```csharp
public static class CollectionExtension : Object
```
    Inheritance: Object


    
    Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




    | Static Method | Description |
    | --- | --- |
| [Add&lt;T&gt;(this ICollection&lt;T&gt; this, IEnumerable&lt;T&gt; elementsToAdd)](CollectionExtension_Add-T-(ICollection-T-,IEnumerable-T-)) | adds all elements in a parametrized list into an existing collection |
| [AddMissing&lt;T&gt;(this ICollection&lt;T&gt; this, IEnumerable&lt;T&gt; elementsToAdd)](CollectionExtension_AddMissing-T-(ICollection-T-,IEnumerable-T-)) | adds all elements in a parametrized list into an existing collection if the collection already contains an element it skips it |
| [AddMissing&lt;T,TSelectorType&gt;(this ICollection&lt;T&gt; this, IEnumerable&lt;T&gt; elementsToAdd, Func&lt;T, TSelectorType&gt; selector)](CollectionExtension_AddMissing-T,TSelectorType-(ICollection-T-,IEnumerable-T-,Func-T,TSelectorType-)) | adds all elements in a parametrized list into an existing collection if the collection already contains an element it skips it |
