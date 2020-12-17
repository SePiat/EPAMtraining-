using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextProcessor.Core;
using TextProcessor.ReaderWriter;

namespace TextProcessor
{
    public class TextModelCreator: ITextModelCreator
    {
        private IReaderText reader = new ReaderText();
        private IParser parser = new Parser();
        private ITextModel textModel = new TextModel();

        public ITextModel CreateTextModel()
        {
            string text = reader.ReadText();//читаем текст из файла
            string textCleaned = TextСleaner.CleanText(text);// очищаем текст от лишних пробелов и переносов
           
            var ListSubSentence = parser.TextParserBySubSentence(textCleaned);//разбивает текст на предложения (не модель продложения, а коллекция строк)
            foreach (var subSentence in ListSubSentence)
            {
                if (subSentence != "")
                    textModel.Text.Add(new Sentence(parser.SentenceOfSybolsParserBySentenceElement
                                                (parser.TextParserSentenceBySymbols(subSentence))));// парсим предложения на колекцию символов, из колекции символов формируем элементы предложения
            }
            return textModel;
        }

    }
}
