[back](/IronSphere.Extensions/types)

# LinqExtensions

> Namespace: IronSphere.Extensions in  IronSphere.Extensions.dll



```csharp
public static class LinqExtensions : Object
```
Inheritance: Object



Attributes:
        
* System.Runtime.CompilerServices.ExtensionAttribute




| Static Method | Description |
| --- | --- |
| [LexTake&lt;TSource&gt;(this IEnumerable&lt;TSource&gt; source, int? count)](LinqExtensions_LexTake-TSource-(IEnumerable-TSource-,Nullable-Int32-)) | Pendent to Linq IEnumerable{TSource}.Take(int) but returns all when count is null |
| [LexSkipLast&lt;TSource&gt;(this IEnumerable&lt;TSource&gt; source, int count)](LinqExtensions_LexSkipLast-TSource-(IEnumerable-TSource-,Int32)) |  |
| [LexTakeLast&lt;TSource&gt;(this IEnumerable&lt;TSource&gt; source, int count)](LinqExtensions_LexTakeLast-TSource-(IEnumerable-TSource-,Int32)) |  |
| [LexSkip&lt;TSource&gt;(this IEnumerable&lt;TSource&gt; source, int? count)](LinqExtensions_LexSkip-TSource-(IEnumerable-TSource-,Nullable-Int32-)) | Pendent to Linq IEnumerable{TSource}.Skip(int) but skips all when count is null |
| [LexLeftJoin&lt;TSource,TJoin,TKey&gt;(this IEnumerable&lt;TSource&gt; source, IEnumerable&lt;TJoin&gt; inner, Func&lt;TSource, TKey&gt; outerKeySelector, Func&lt;TJoin, TKey&gt; innerKeySelector)](LinqExtensions_LexLeftJoin-TSource,TJoin,TKey-(IEnumerable-TSource-,IEnumerable-TJoin-,Func-TSource,TKey-,Func-TJoin,TKey-)) | Performs a left join over two enumerable sequences |
| [LexRightJoin&lt;TSource,TJoin,TKey&gt;(this IEnumerable&lt;TSource&gt; source, IEnumerable&lt;TJoin&gt; inner, Func&lt;TSource, TKey&gt; outerKeySelector, Func&lt;TJoin, TKey&gt; innerKeySelector)](LinqExtensions_LexRightJoin-TSource,TJoin,TKey-(IEnumerable-TSource-,IEnumerable-TJoin-,Func-TSource,TKey-,Func-TJoin,TKey-)) | Performs a right join over two enumerable sequences |
| [LexDistinctBy&lt;TSource,TKey&gt;(this IEnumerable&lt;TSource&gt; source, Func&lt;TSource, TKey&gt; groupingSelector)](LinqExtensions_LexDistinctBy-TSource,TKey-(IEnumerable-TSource-,Func-TSource,TKey-)) | Returns distinct elements from a sequence by using a selected property to compare values. |
