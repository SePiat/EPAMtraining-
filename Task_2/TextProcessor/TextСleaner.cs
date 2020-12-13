using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public class TextСleaner
    {
        private string pattern1 = @"(\r\n)+"; //удаляет множестуенные переносы стоки
        public string CleanText(string text)
        {
            string cleanedText = Regex.Replace(text, pattern1, "");
            return cleanedText;
        }
    }
}
