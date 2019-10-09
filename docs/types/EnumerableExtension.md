[back](/IronSphere.Extensions/types)

# EnumerableExtension Class

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll

This class provides extension methods for &lt;see cref=&quot;T:System.Collections.Generic.IEnumerable`1&quot; /&gt;

```csharp
public static class EnumerableExtension : Object
```
Inheritance: Object



Attributes:

* System.Runtime.CompilerServices.ExtensionAttribute



| Static Method | Description |
| --- | --- |
| [IsNullOrEmpty&lt;T&gt;(this IEnumerable&lt;T&gt; this)](EnumerableExtension_IsNullOrEmpty-T-(IEnumerable-T-)) | Determines whether an &lt;see cref=&quot;T:System.Collections.Generic.IEnumerable`1&quot; /&gt; is either null or doesn&#39;t contain any elements |
| [IsSingle&lt;T&gt;(this IEnumerable&lt;T&gt; this)](EnumerableExtension_IsSingle-T-(IEnumerable-T-)) | Determines if an enumeration contains exactly one element |
| [IsSingle&lt;T&gt;(this IEnumerable&lt;T&gt; this, Func&lt;T, bool&gt; predicate)](EnumerableExtension_IsSingle-T-(IEnumerable-T-,Func-T,Boolean-)) | Determines if an enumeration contains exactly one element |
| [Randomize&lt;T&gt;(this IEnumerable&lt;T&gt; this)](EnumerableExtension_Randomize-T-(IEnumerable-T-)) | Randomizes the items of a list |
| [Distinct&lt;T,TType&gt;(this IEnumerable&lt;T&gt; this, Func&lt;T, TType&gt; expression)](EnumerableExtension_Distinct-T,TType-(IEnumerable-T-,Func-T,TType-)) | Iterates through a list of items and yields all elements but not duplicated. |
