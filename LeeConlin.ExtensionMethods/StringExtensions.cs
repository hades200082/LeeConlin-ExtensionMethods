using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;

namespace LeeConlin.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all non-alphanumeric characters from a string, replacing them with hyphens.
        /// Ensures only one hyphen regardless of the number of consecutive non-alphanumeric characters.
        /// Will remove diacritics, replacing them with the visually closest latin character 
        /// </summary>
        /// <param name="text">The string you want to make URL friendly</param>
        /// <returns>A string that can be used in a URL safely. e.g. "Some aweful ~~~string~~~ with lots of $peci@l ch@racters" becomes "Some-aweful-string-with-lots-of-peci-l-ch-racters"</returns>
        public static string ToUrlFriendlyString(this string text)
        {
            text = text.RemoveDiacritics();

            Regex rgx = new Regex(@"[^a-zA-Z0-9\-]");
            text = rgx.Replace(text, "-");
            text = Regex.Replace(text, @"-+", "-");
            text = text.Trim('-');

            return text.ToLowerInvariant();
        }

        /// <summary>
        /// Removed diacritics, replacing them with the visually closest latin character
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A string with the diacritics replaced with their visually closest matching latin characters. e.g. "Thérèse" becomes "Therese".</returns>
        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Converts the plain text to a Base64 encoded string
        /// </summary>
        /// <param name="text">The text to encode</param>
        /// <param name="encoding">The encoding to use (defaults to UTF8)</param>
        /// <returns>A string containing a Base64 encoded representation of the input string.</returns>
        public static string ToBase64(this string text, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var plainTextBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Converts Base64 encoded text back into a regular string.
        /// </summary>
        /// <param name="base64EncodedText">The Base64 encoded text to decode</param>
        /// <param name="encoding">The encoding to use (defaults to UTF8)</param>
        /// <returns>Reverses Base64 encoding, returning the original, unencoded string.</returns>
        public static string FromBase64(this string base64EncodedText, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedText);
            return encoding.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Find the Nth index of a character within a string.
        /// For example, in the string "a1a2a3a4a5", find the index of the 3rd 'a'.
        /// </summary>
        /// <param name="text">The text to search</param>
        /// <param name="ch">The character to search for</param>
        /// <param name="n">The number of the specified character to count</param>
        /// <returns>The integer index of the nth instance of the specified character within the string.</returns>
        public static int NthIndexOf(this string text, char ch, int n)
        {
            var result = text
                .Select((c, i) => new {c, i})
                .Where(x => x.c == ch)
                .Skip(n - 1)
                .FirstOrDefault();
            return result?.i ?? -1;
        }

        /// <summary>
        /// Truncates text based on options selected.
        /// </summary>
        /// <param name="text">The text to truncate</param>
        /// <param name="maxLength">The maximum length (based on style selected) of the text to be returned</param>
        /// <param name="style">
        /// MaxCharacters will cut off the string at that number of characters.
        /// MaxWords will cut off the string at that number of words (using space as word-break).
        /// MaxCharactersAtWordBoundry will attempt to cut the string at a word boundary, keeping the text below the character count requested.
        /// </param>
        /// <param name="stringToAppendIfTruncated">If provided, will append the given string to the truncated text.</param>
        /// <returns>The truncated string.</returns>
        public static string Truncate(this string text, int maxLength,
            StringTruncateStyle style = StringTruncateStyle.MaxCharacters, string stringToAppendIfTruncated = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            switch (style)
            {
                default:
                    //case TruncateStyle.MaxCharacters:
                    text = text.Length <= maxLength
                        ? text
                        : text.Substring(0, maxLength).TrimEnd() + stringToAppendIfTruncated;
                    break;
                case StringTruncateStyle.MaxWords:
                    if (text.Count(x => x == ' ') > maxLength)
                    {
                        text = text.Substring(0, text.NthIndexOf(' ', maxLength)).TrimEnd() + stringToAppendIfTruncated;
                    }

                    break;
                case StringTruncateStyle.MaxCharactersAtWordBoundry:
                    if (!(text.Length <= maxLength))
                    {
                        text = text.Substring(0, maxLength + 1);

                        var lastIndex = text.LastIndexOf(' ');
                        text = text.Substring(0, lastIndex == -1 ? maxLength : lastIndex)
                            .TrimEnd(',',';',':','.','!','?',' ');
                        text = text + stringToAppendIfTruncated;
                    }

                    break;
            }

            return text;
        }

        /// <summary>
        /// Create an MD5 hash of a string of text.
        /// </summary>
        /// <param name="text">Text to hash</param>
        /// <param name="uppercase"></param>
        /// <returns>The MD5 hash of the input string</returns>
        public static string ToMd5Hash(this string text, bool uppercase = true)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(uppercase ? b.ToString("X2") : b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Create an SHA1 hash of a string of text.
        /// </summary>
        /// <param name="text">Text to hash</param>
        /// <param name="uppercase"></param>
        /// <returns>The SHA1 hash of the input string</returns>
        public static string ToSha1Hash(this string text, bool uppercase = true)
        {
            using (var sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(uppercase ? b.ToString("X2") : b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Create an SHA256 hash of a string of text.
        /// </summary>
        /// <param name="text">Text to hash</param>
        /// <param name="uppercase"></param>
        /// <returns>The SHA256 hash of the input string</returns>
        public static string ToSha256Hash(this string text, bool uppercase = true)
        {
            using (var sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(uppercase ? b.ToString("X2") : b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        

        /// <summary>
        /// Create an SHA512 hash of a string of text.
        /// </summary>
        /// <param name="text">Text to hash</param>
        /// <param name="uppercase"></param>
        /// <returns>The SHA512 hash of the input string</returns>
        public static string ToSha512Hash(this string text, bool uppercase = true)
        {
            using (var sha512 = new System.Security.Cryptography.SHA512Managed())
            {
                var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(uppercase ? b.ToString("X2") : b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts the textual representation of an integer to an int data type.
        /// If not possible, returns 0.
        /// Examples:
        /// var value = "6".ToInt(); // int value = 6;
        /// var value = "ab6".ToInt(); // int value = 0;
        /// var value = "6.2".ToInt(); // int value = 0;
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The int represented by the string, or 0 if the string doesn't represent an int (or represents 0).</returns>
        public static int ToInt(this string text)
        {
            return int.TryParse(text,
                NumberStyles.Integer |
                NumberStyles.AllowThousands |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite |
                NumberStyles.AllowLeadingSign,
                Thread.CurrentThread.CurrentCulture, out int output)
                ? output
                : 0;
        }

        /// <summary>
        /// Converts the textual representation of a decimal to a decimal data type.
        /// If not possible, returns 0.
        /// Examples:
        /// var value = "6.2".ToDecimal(); // decimal value = 6.2m;
        /// var value = "$6.2".ToDecimal(); // decimal value = 6.2m;
        /// var value = "6".ToDecimal(); // decimal value = 6.0m;
        /// var value = "6..".ToDecimal(); // decimal value = 0m;
        /// var value = "ab6".ToDecimal(); // decimal value = 0m;
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The decimal represented by the string, or 0m if the string doesn't represent a decimal (or represents 0m).</returns>
        public static decimal ToDecimal(this string text)
        {
            text = text.Trim(); // remove leading & trailing whitespace
            return decimal.TryParse(text,
                NumberStyles.AllowCurrencySymbol | NumberStyles.Currency | NumberStyles.Number |
                NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                Thread.CurrentThread.CurrentCulture,
                out decimal output)
                ? output
                : 0m;
        }

        /// <summary>
        /// Attempts to discern truethyness from a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>True if the string is "truthy", otherwise false.</returns>
        public static bool IsTruthy(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            
            switch (text.ToLowerInvariant())
            {
                case "yes":
                case "true":
                case "1":
                case "yep":
                case "y":
                    return true;

                default:
                    if (text.ToInt() != 0) return true;
                    if (text.ToDecimal() != 0) return true;
                    
                    // otherwise it's not truthy
                    return false;
            }
        }

        /// <summary>
        /// Attempts a simple XML deserialisation into an object of the specified type. Will use XML attributes on the target types class if present.
        /// </summary>
        /// <param name="xml"></param>
        /// <typeparam name="T">The type to deserialise into.</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T FromXml<T>(this string xml)
            where T : class, new()
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentNullException(nameof(xml));

            var serializer = new XmlSerializer(typeof(T));
            T result;
            
            using (TextReader reader = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }
    }

    public enum StringTruncateStyle
    {
        MaxCharacters,
        MaxWords,
        MaxCharactersAtWordBoundry
    }
}