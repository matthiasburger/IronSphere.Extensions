using System.Text;

namespace IronSphere.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendIf(this StringBuilder stringBuilder, bool condition, string textToAppend) 
            => condition ? stringBuilder.Append(textToAppend) : stringBuilder;
    }
}
