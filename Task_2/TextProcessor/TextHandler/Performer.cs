using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextProcessor.Core;
using TextProcessor.ReaderWriter;

namespace TextProcessor.TextHandler
{
    public class Performer : IPerformer
    {
        public ITextModelCreator Creator { get; set; } = new TextModelCreator();
        public ITextModel TextModel { get; set; } = new TextModel();
        private IWriterText writer = new WriterText();

        public void Perform()
        {
            TextModel = Creator.CreateTextModel();
        }

        public List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel)//Предложения заданного текста в порядке возрастания количества слов в каждом из них.
        {
            var result = textModel.Text.Where(x => x.SentenceElements.
             Where(x => x is Word).Count() > 0).OrderBy(x => x.SentenceElements.Where(x => (x is Word)).Count()).ToList();
            return result;
        }


        public List<string> WordsSetLengthByQuestionableSentences(ITextModel textModel)// Слова заданной длины из вопросительных предложений
        {

            List<string> listWords = new List<string>();
            List<string> listWordsDistinct = new List<string>();


            Console.WriteLine("Для поиска слов заданной длины в вопросительных предложениях задайте длину слова");
            bool iswordLengthSuccess = int.TryParse(Console.ReadLine(), out int wordLength);
            if (iswordLengthSuccess)
            {
                List<ISentence> questionableSentence = textModel.Text.
                Where(x => x.SentenceElements.
                Where(x => x.Symbols.
                Where(x => x.Character == '?').Count() > 0).Count() > 0).ToList(); //выбираем все вопросительные предложения                

                writer.WriteQuestionableSentences(questionableSentence);

                foreach (var sentence in questionableSentence)
                {
                    listWords.AddRange(sentence.SentenceElements.
                        Where(x => x is Word).
                        Where(x => x.Symbols.Count() == wordLength).
                        Select(x => (Word)x).
                        Select(x => x.stringWord));
                } //выбираем слова подходящей длины и добавляем их в колекцию слов

                listWordsDistinct.AddRange(listWords.Distinct());// добовляем в колекцию listWordsDistinct уникальные слова из listWords

            }
            else Console.WriteLine("Ошибка. Введено не числовое значение");

            return listWordsDistinct;
        }

        public void TextModelWithoutWordsOfSetLengthWithСonsonantLetter(ITextModel textModel)// удаляет из текста слова заданной длины, начинающиеся на согласную
        {           
            List<ISentenceElement> selectedWords = new List<ISentenceElement>();
            Console.WriteLine("Для удаления из текста всех слова заданной длины, начинающиеся на согласную букву задайте длину слова");
            bool iswordLengthSuccess = int.TryParse(Console.ReadLine(), out int wordLength);
            if (iswordLengthSuccess)
            {               
                char[] consonantsEnglish = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M','N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z', 
                                        'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','y','z' };
                foreach (var sentence in textModel.Text)
                {
                    selectedWords.AddRange(sentence.SentenceElements.
                    Where(x => consonantsEnglish.Contains(x.Symbols[0].Character) && x.Symbols.Count() == wordLength));

                    selectedWords.ForEach(x => sentence.SentenceElements.Remove(x));
                    selectedWords.Clear();
                } 
            }
            else Console.WriteLine("Ошибка. Введено не числовое значение");           
        }

        public void TextModelExchangeWordOfSetLengthWhithString(ITextModel textModel)
        {
            List<ISentenceElement> selectedWords = new List<ISentenceElement>();
            Console.WriteLine("Для замены слов заданной длины в указанном предложении указанной строкой укажите номер предложения");
            bool isNubmerOfSentenceSuccess = int.TryParse(Console.ReadLine(), out int NubmerOfSentence);
            Console.WriteLine("Укажите длину заменяемых слов");
            bool iswordLengthSuccess = int.TryParse(Console.ReadLine(), out int wordLength);
            Console.WriteLine("Введите, вставляемую строку");
            string embedString = Console.ReadLine()+" ";

            IParser parser = new Parser();
            List<ISymbol> embedStringBySymbols= parser.ParserTextBySymbols(embedString);
            List<ISentenceElement> embedStringBySentenceElements = parser.CollectionSymbolFromTextParserBySentenceElement(embedStringBySymbols); 

            if (isNubmerOfSentenceSuccess&& iswordLengthSuccess)
            {
                var selectedSentence= textModel.Text[NubmerOfSentence];
                selectedWords.AddRange(selectedSentence.SentenceElements.Where(x => x.Symbols.Count() == wordLength)); // находим и записывыем словa в указанном предложении подходящие по длине
                foreach (var selectedWord in selectedWords)
                {
                    int indexToRewrite = selectedSentence.SentenceElements.IndexOf(selectedWord);//определяем индес слова подходящего по длине
                    selectedSentence.SentenceElements.Remove(selectedWord);//удаляем слово подходящего по длине
                    selectedSentence.SentenceElements.InsertRange(indexToRewrite, embedStringBySentenceElements);//на место удаленного слова вставляем заданное предложение                       
                }
            }
            else Console.WriteLine("Ошибка. Введены некорректные исхоные данные");

        }

    }
}



