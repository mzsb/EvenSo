namespace EvenSo
{
    internal static class Strings
    {
        internal static string ToCamelCase(this string str) => str.IsNotNull(() => str.ToCase(char.ToLower));

        internal static string ToPascalCase(this string str) => str.IsNotNull(() => str.ToCase(char.ToUpper));

        internal static string ToCase(this string str, Func<char, char> caseFunction)
        {
            if(str.Length == 0) return str;

            var cased = caseFunction(str[0]);

            return str.Length == 1 ? cased.ToString() : cased + str[1..];
        }
    }
}
