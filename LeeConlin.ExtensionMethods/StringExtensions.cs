using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        public static string ToBase64(this string text, Encoding encoding = null)
        {
            if(encoding == null) encoding = Encoding.UTF8;
            var plainTextBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Converts Base64 encoded text back into a regular string.
        /// </summary>
        /// <param name="base64EncodedText">The Base64 encoded text to decode</param>
        /// <param name="encoding">The encoding to use (defaults to UTF8)</param>
        /// <returns></returns>
        public static string FromBase64(this string base64EncodedText, Encoding encoding = null)
        {
            if(encoding == null) encoding = Encoding.UTF8;
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
        /// <returns></returns>
        public static int NthIndexOf(this string text, char ch, int n)
        {
            var result = text
                .Select((c, i) => new { c, i })
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
        /// <returns></returns>
        public static string Truncate(this string text, int maxLength, StringTruncateStyle style = StringTruncateStyle.MaxCharacters, string stringToAppendIfTruncated = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            switch (style)
            {
                default:
                    //case TruncateStyle.MaxCharacters:
                    text = text.Length <= maxLength ? text : text.Substring(0, maxLength).TrimEnd() + stringToAppendIfTruncated;
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
                        text = text.Substring(0, text.LastIndexOf(' ')).TrimEnd();
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
    }
    
    public enum StringTruncateStyle
    {
        MaxCharacters,
        MaxWords,
        MaxCharactersAtWordBoundry
    }
}