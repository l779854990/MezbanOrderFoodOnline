using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MezbanCommon.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />, using the specified separator between each member. Null or empty member will be excluded from joining.
        /// </summary>
        /// <returns>A string that consists of the members of <paramref name="source" /> delimited by the <paramref name="separator" /> string. If <paramref name="source" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
        /// <param name="separator">The string to use as a separator. <paramref name="separator" /> is included in the returned string only if <paramref name="source" /> has more than one element.</param>
        /// <param name="source">A collection that contains the strings to concatenate.</param>
        public static string JoinStrings(this IEnumerable<string> source, string separator)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            return string.Join(separator, source.Where(x => !string.IsNullOrEmpty(x)));
        }

        public static string JoinIntegersToString(this IEnumerable<int> source, string separator)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            return string.Join(separator, source.Select(x => x.ToString()));
        }

        public static List<string> WrapText(this string source, int width)
        {
            string[] originalLines = source.Split(new string[] {" "}, StringSplitOptions.None);
            List<string> wrappedLines = new List<string>();
            var actualLine = new StringBuilder();
            int actualWidth = 0;

            foreach (var item in originalLines)
            {
                actualLine.Append(item + " ");
                actualWidth += item.Length;

                if (actualWidth > width)
                {
                    wrappedLines.Add(actualLine.ToString());
                    actualLine.Clear();
                    actualWidth = 0;
                }
            }

            if (actualLine.Length > 0)
                wrappedLines.Add(actualLine.ToString());

            return wrappedLines;
        }

        public static MemoryStream ToMemoryStream(this string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            return new MemoryStream(bytes);
        }

        public static bool IsSpecialChar(this char c)
        {
            const string specialChars = "!@#$%^&*()_-+=[{]};:<>|./?";
            return specialChars.Contains(c);
        }

        public static bool IsValidPassword(this string password)
        {
            // the password needs to be at least 8 characters,
            // contain an uppercase, lowercase, digit and a special char

            // TODO: exception if password == null;
            if (password.Length < 8) return false;

            bool uppercaseDetected = false;
            bool lowercaseDetected = false;
            bool digitDetected = false;
            bool specialCharDetected = false;

            using (IEnumerator<char> enumerator = password.GetEnumerator())
            {
                while (enumerator.MoveNext()
                       && !(uppercaseDetected && lowercaseDetected
                                              && digitDetected && specialCharDetected))
                {
                    // a character is available, and we still don't know if it is a proper password
                    char c = enumerator.Current;
                    uppercaseDetected = uppercaseDetected || Char.IsUpper(c);
                    lowercaseDetected = lowercaseDetected || Char.IsLower(c);
                    digitDetected = digitDetected || Char.IsDigit(c);
                    specialCharDetected = specialCharDetected || c.IsSpecialChar();
                }

                return uppercaseDetected && lowercaseDetected
                                         && digitDetected && specialCharDetected;
            }
        }
    }
}