namespace SqlToCSharp.Classes
{
    public static class StringArrayExtensions
    {
        public static bool ContainsStartingWith(this string[] items, string value)
        {
            foreach (var item in items)
            {
                if (item.StartsWith(value))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool StartsWithAnItemInArray(this string value, string[] items)
        {
            foreach (var item in items)
            {
                if (value.StartsWith(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
