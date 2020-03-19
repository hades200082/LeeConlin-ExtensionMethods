namespace LeeConlin.ExtensionMethods
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Converts true/false to Yes/No
        /// </summary>
        /// <param name="val"></param>
        /// <returns>A string containing "Yes" or "No" based on the input bool</returns>
        public static string ToYesNo(this bool val)
        {
            return val ? "Yes" : "No";
        }
    }
}