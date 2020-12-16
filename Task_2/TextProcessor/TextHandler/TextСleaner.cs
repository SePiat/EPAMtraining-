using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public static class TextСleaner
    {
        private static string pattern1 = @"(\r\n)+";
        private static string pattern2 = @"( {2,})";
        public static string CleanText(string text)
        {
            string cleanedText = Regex.Replace(text, pattern1, " "); //удаляет множественные переносы строки
            cleanedText = Regex.Replace(cleanedText, pattern2, " "); //удаляет множественные пробелы
            return cleanedText;
        }
    }
}
