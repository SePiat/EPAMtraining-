using System;
using System.Collections.Generic;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            TextModelCreator tmc = new TextModelCreator();
            ITextModel textModel = tmc.CreateTextModel();

            /*ReaderText reader = new ReaderText();
            TextСleaner tcleaner = new TextСleaner();
            Parser parser = new Parser();            
            TextModel textModel = new TextModel();

            string text = reader.ReadText();
            string textCleaned = tcleaner.CleanText(text);
            var ListSubSentence = parser.TextParserBySubSentence(textCleaned);
            foreach (var subSentence in ListSubSentence)
            {
                textModel.text.Add(new Sentence(parser.SentenceOfSybolsParserBySentenceElement
                                                (parser.TextParserSentenceBySymbols(subSentence))));

            }*/


           




            Console.WriteLine("Hello World!");
        }
    }
}
