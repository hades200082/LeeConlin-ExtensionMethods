namespace LeeConlin.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsTruthy(this int i)
        {
            return i != 0;
        }
    }
}