using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

using Xunit;

namespace IronSphere.Extensions.Test
{
    public class Documentation
    {
        public int Test { get; set; }

        public static void Main(string[] args)
        {
            Documentation d = new Documentation();
            Expression<Func<Documentation, int>> expr = x => x.Test;
            LambdaExpression lambdaExp = Expression.Lambda(expr);
            d.SetPropertyValue(lambdaExp, 5);
        }
    }

    public class ExtensionTest
    {
        [Fact]
        public void TestNewTo()
        {
            string x = 1.To<string>();
            Assert.Equal("1", x);
        }
    }
    
}
