using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextProcessor.Core;
using TextProcessor.ReaderWriter;

namespace TextProcessor
{
    public class TextModelCreator
    {
        private IReaderText reader = new ReaderText();
        private Parser parser = new Parser();
        private ITextModel textModel = new TextModel();

        public ITextModel CreateTextModel()
        {
            string text = reader.ReadText();
            string textCleaned = TextСleaner.CleanText(text);
            WriterText wr = new WriterText();
            wr.WriteText(textCleaned);
            var ListSubSentence = parser.TextParserBySubSentence(textCleaned);

            foreach (var subSentence in ListSubSentence)
            {
                if (subSentence != "")
                    textModel.Text.Add(new Sentence(parser.SentenceOfSybolsParserBySentenceElement
                                                (parser.TextParserSentenceBySymbols(subSentence))));
            }
            return textModel;
        }

    }
}
