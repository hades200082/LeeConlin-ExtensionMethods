using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using LeeConlin.ExtensionMethods.ExtendedClasses;

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

        /// <summary>
        /// Attempts a simple conversion of the object to XML. Will use XML attributes on the target class if present.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="encoding">Defaults to UTF-8 if null</param>
        /// <typeparam name="T">Any simple POCO</typeparam>
        /// <returns>A string of XML</returns>
        /// <exception cref="System.InvalidOperationException">Throws an exception if it can't generate XML</exception>
        public static string ToXml<T>(this T obj, Encoding encoding = null)
            where T : class, new()
        {
            var xsSubmit = new XmlSerializer(typeof(T));
            string xml;
            using(var sww = new EncodingSpecificStringWriter(encoding))
            {
                using(var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                }

                xml = sww.ToString();
            }

            return xml;
        }
    }
}