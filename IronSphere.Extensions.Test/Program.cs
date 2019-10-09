using System;
using System.ComponentModel;
using System.Globalization;

using Xunit;

namespace IronSphere.Extensions.Test
{
    public class Documentation
    {
        public static void Main(string[] args)
        {

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
