using System;
using System.Linq;

namespace LeeConlin.ExtensionMethods
{
    public static class UriExtensions
    {
        public static string ToCommonUrlString(this Uri uri)
        {
            switch (uri.Port)
            {
                case 80 when uri.Scheme.ToLower() == "http":
                case 443 when uri.Scheme.ToLower() == "https":
                case 21 when uri.Scheme.ToLower() == "ftp":
                    return uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port,
                        UriFormat.UriEscaped);
                
                default: return uri.ToString();
            }
        }
    }
}