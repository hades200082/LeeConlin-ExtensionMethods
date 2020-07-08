using System;

namespace LeeConlin.ExtensionMethods
{
    public static class UriBuilderExtensions
    {
        public static string ToCommonUrlString(this UriBuilder uriBuilder)
        {
            return uriBuilder.Uri.ToCommonUrlString();
        }
    }
}