using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class TextModelCreator
    {
        ReaderText reader = new ReaderText();
        TextСleaner tcleaner = new TextСleaner();
        Parser parser = new Parser();
        TextModel textModel = new TextModel();

        public TextModel CreateTextModel()
        {
            string text = reader.ReadText();
            string textCleaned = tcleaner.CleanText(text);
            var ListSubSentence = parser.TextParserBySubSentence(textCleaned);
            foreach (var subSentence in ListSubSentence)
            {
                textModel.text.Add(new Sentence(parser.SentenceOfSybolsParserBySentenceElement
                                                (parser.TextParserSentenceBySymbols(subSentence))));

            }
            return textModel;
        }

    }
}
