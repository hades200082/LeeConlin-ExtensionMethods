namespace LeeConlin.ExtensionMethods
{
    public static class DecimalExtensions
    {
        public static bool IsTruthy(this decimal i)
        {
            return i != 0;
        }
    }
}