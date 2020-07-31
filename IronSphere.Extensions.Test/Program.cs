using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

using JetBrains.Annotations;

using Xunit;

namespace IronSphere.Extensions.Test
{
    using System;

    class Program
    {
        int GetUserInput()
        {
            string input = null;
            int value;
            while (!int.TryParse(input, out value))
            {
                Console.Write("Please enter a number: ");
                input = Console.ReadLine();
            }
            return value;
        }

        static void Main()
        {
            IEnumerable<int> originalList = new List<int> { 1, 2, 3, 4 };
            IEnumerable<int> result = originalList.AddItem(5)
                .If((list, @new) => !list.Contains(@new));

            var res1 = result.ToList();
            var res2 = result.ToList();


            var x = new Program().GetUserInput();
            Console.WriteLine(x);
        }
    }

    public class Documentation
    {
        public int Test { get; set; }

        // public static void Main(string[] args)
        // {
        //     Documentation d = new Documentation();
        //     Expression<Func<Documentation, int>> expr = x => x.Test;
        //     LambdaExpression lambdaExp = Expression.Lambda(expr);
        //     d.SetPropertyValue(lambdaExp, 5);
        // }

        [ContractAnnotation("i:null => null")]
        public bool? GetBoolValue(int? i)
        {
            return i != 1;
        }

        public static void MainOld(string[] args)
        {
            DateTime? scheduledTime = _getNextWorkingTime(DateTime.Now);
        }

        public static IEnumerable<TSource> Assert<TSource>(IEnumerable<TSource> source,
            Func<TSource, bool> predicate, Func<TSource, Exception> errorSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return _();

            IEnumerable<TSource> _()
            {
                foreach (var element in source)
                {
                    var success = predicate(element);
                    if (!success)
                        throw errorSelector?.Invoke(element) ?? new InvalidOperationException("Sequence contains an invalid item.");
                    yield return element;
                }
            }
        }


        private static DateTime? _getNextWorkingTime(DateTime initialTime)
        {
            DateTime? scheduleDate = null;

            TimeSpan x = initialTime.TimeOfDay;
            Random r = new Random();
            if (x.IsBefore(new TimeSpan(8, 0, 0)))
            {
                int hours = r.Next(8, 12);
                scheduleDate = initialTime.SetTime(new TimeSpan(hours, initialTime.Minute, initialTime.Second));
            }
            else if (x.IsAfter(initialTime.SetTime(new TimeSpan(16, 30, 0)).TimeOfDay))
            {
                int hours = r.Next(8, 12);
                scheduleDate = initialTime.SetTime(new TimeSpan(hours, initialTime.Minute, initialTime.Second));
            }

            if (scheduleDate.HasValue && scheduleDate.Value.IsWeekend())
                scheduleDate = scheduleDate.Value.Next(DayOfWeek.Monday);

            return scheduleDate;
        }
    }

    public class MyClass
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static MyClass Init(long id, string name) => new MyClass { Name = name, Id = id };
    }


    public class ExtensionTest
    {
        [Fact]
        public void TestNewTo()
        {
            string x = 1.To<string>();
            Assert.Equal("1", x);
        }

        public class Obj
        {
            public object Var1 { get; set; }
            public object Var2 { get; set; }
        }

        public class DbSet
        {
            public object someVar;
            public object var2;
        }

        [Fact]
        public void TestGetSingleItem()
        {
            List<MyClass> list = new List<MyClass>{
                new MyClass{Id=3, Name="bla"},new MyClass{Id=2, Name="bla"},new MyClass{Id=1, Name="bla"}
            };

            string[] bla = new[] { "test", "bla" };

            Expression<Func<MyClass, string, bool>> f = (x, y) => !y.IsNullOrWhiteSpace() || x.Name.ToLower(CultureInfo.CurrentCulture) == new string(new[] { new Dictionary<int, string> { { 1, MyClass.Init(2, "test").Name }, { 1, "a" } }[1].First() });

            Expression<Func<MyClass, string, bool>> filter = (x, y) => (!y.IsNullOrWhiteSpace() || (x.Name.ToLower(CultureInfo.CurrentCulture) == new String(new[] { new Dictionary<Int32, List<String>>(2) { { 1, new List<String>() { { MyClass.Init(2L, "test").Name } } }, { 1, new List<String>() { { "a" }, { "b" } } } }[1].First().First() })));
            // Expression<Func<MyClass, bool>> filtor = x => (! StringExtension.IsNullOrWhiteSpace(x.Name) || (x.Name.ToLower(CultureInfo.CurrentCulture) == list.get_Item(0).Name));

            string readable = filter.GetReadableExpressionBody();

            int s = 3;

            var res = list.GetSingleItem(x => x.Id == 2);

            Assert.Equal("1", "1");
        }

    }
}
