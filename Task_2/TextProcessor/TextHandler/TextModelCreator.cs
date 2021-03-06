﻿using System;
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
            try
            {
                reader.ReadTextString(parser);//читаем текст из файла и преобразуем считанный текст в символы
                List<ISymbol> collextionSymbols = parser.CollectionSymbolFromText;
                List<ISentenceElement> SentenceElements = parser.CollectionSymbolFromTextParserBySentenceElement(collextionSymbols);//создаем из колекции символов элементы предложения
                List<ISentence> sentences = parser.GetColletionSentencesByISentenceElemtnts(SentenceElements);// групперуем элементы предложения в предложения
                textModel.Text.AddRange(sentences);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе CreateTextModel() : {ex}");
            }           
            return textModel;
        }

    }
}
