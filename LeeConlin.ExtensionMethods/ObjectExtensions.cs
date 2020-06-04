namespace LeeConlin.ExtensionMethods
{
    /// <summary>
    /// Object extension methods for extensions that exist on multiple types
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determines if an object is truthy
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsTruthy(this object obj)
        {
            switch (obj)
            {
                case string s:
                    return s.IsTruthy();
                case int i:
                    return i.IsTruthy();
                case decimal @decimal:
                    return @decimal.IsTruthy();
                case double d:
                    return d.IsTruthy();
                case bool b:
                    return b;
            }

            return false;
        }
    }
}