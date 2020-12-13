using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor
{
    public class Word : ISentenceElement
    {
        public Word(char[] characters)
        {
            Characters = characters;
        }

        public string word { get; set; }
        public char[] Characters { get; set; }
        public int IndexInSentence { get; set; }

        public string GetWordFromCharArray(char[] characters)
        {
            for (int i = 0; i < characters.Length-1; i++)
            {
                word.Append(characters[i]);
            }
           return word;
        }
    }
}