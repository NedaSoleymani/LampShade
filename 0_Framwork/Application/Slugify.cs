using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public static class Slugify
    {
        public static string Slugfiy(this string phrase)
        {
            var s = phrase.RemoveDiacritics().ToLower();
            s = Regex.Replace(s, @"[^\u0600-\u06FF\u0FBBA\u067E\u0686\u06AF\u06AF\u200c\u200Fa-z0-9\s-]",
                "");//remove invalid characters
            s = Regex.Replace(s, @"\s+", " ").Trim();//single space
            s = s.Substring(0, s.Length <= 100 ? s.Length : 45).Trim();//cutt and trim
            s = Regex.Replace(s, @"\s", "-");//insert hyphens
            s = Regex.Replace(s, @"", "-");//helf space     
            return s.ToLower();      
        }

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

            var normalizedString = text.Normalize(NormalizationForm.FormKC);
            var stringBulider = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory!=UnicodeCategory.NonSpacingMark)
                {
                    stringBulider.Append(c);

                }
            }

            return stringBulider.ToString().Normalize(NormalizationForm.FormC); ;
        }
    }
}
