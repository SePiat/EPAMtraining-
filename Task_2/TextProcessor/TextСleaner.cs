using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public class TextСleaner
    {
        private string pattern1 = @"(\r\n)+"; //удаляет множественные переносы строки
        private string pattern2 = @"( {2,})"; //удаляет множественные пробелы
        public string CleanText(string text)
        {
            string cleanedText = Regex.Replace(text, pattern1, "\r\n");
            cleanedText= Regex.Replace(cleanedText, pattern2, " ");

            return cleanedText;
        }
    }
}
