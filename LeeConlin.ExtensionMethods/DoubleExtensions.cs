using System;

namespace LeeConlin.ExtensionMethods
{
    public static class DoubleExtensions
    {
        public static bool IsTruthy(this double i)
        {
            // This will work in most cases. A simple == or != would fall 
            // afoul of precision issues
            return i > 0.0000000001 || i < -0.0000000001;
        }
    }
}