namespace SqlToCSharp.Classes
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method on string array, which checks if there is any element in array which starts with specified value.
        /// </summary>
        /// <param name="items">string array</param>
        /// <param name="value">string value to compare with.</param>
        /// <returns>True, if there is any element in array which starts with specified value. </returns>
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

        /// <summary>
        /// Extension method on string, which checks if string value starts with any element present in specified string array.
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="items">String arrray aginst which comparson will be made.</param>
        /// <returns>True, if string value starts with any element present in specified string array.</returns>
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
