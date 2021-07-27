using System.IO;
using System.Text;

namespace LeeConlin.ExtensionMethods.ExtendedClasses
{
    /// <inheritdoc />
    public class EncodingSpecificStringWriter : StringWriter
    {
        /// <inheritdoc />
        public override Encoding Encoding { get; }

        /// <summary>
        /// Allows passing of a specific encoding
        /// </summary>
        /// <param name="encoding"></param>
        public EncodingSpecificStringWriter(Encoding encoding = null)
        {
            Encoding = encoding ?? Encoding.UTF8;
        }
    }
}