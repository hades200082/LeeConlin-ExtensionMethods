namespace LeeConlin.ExtensionMethods
{
    public static class BoolExtensions
    {
        public static string ToYesNo(this bool val)
        {
            return val ? "Yes" : "No";
        }
    }
}