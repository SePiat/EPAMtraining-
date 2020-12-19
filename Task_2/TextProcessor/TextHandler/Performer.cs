using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<ISentenceElement> words = new List<ISentenceElement>();
            Console.WriteLine("Для удаления из текста всех слова заданной длины, начинающиеся на согласную букву задайте длину слова");
            bool iswordLengthSuccess = int.TryParse(Console.ReadLine(), out int wordLength);
            if (iswordLengthSuccess)
            {               
                char[] consonantsEnglish = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M','N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z', 
                                        'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','y','z' };
                foreach (var sentence in textModel.Text)
                {
                    /*foreach (var sentenceElement in sentence.SentenceElements)
                    {
                        if (consonantsEnglish.Contains(sentenceElement.Symbols[0].Character) && sentenceElement.Symbols.Count() == wordLength)
                        {
                            sentence.SentenceElements.Remove(sentenceElement);
                        }
                    }*/// не может удалить элемент во время перечисления
                    words.AddRange(sentence.SentenceElements.
                    Where(x => consonantsEnglish.Contains(x.Symbols[0].Character) && x.Symbols.Count() == wordLength));

                    words.ForEach(x => sentence.SentenceElements.Remove(x));
                    words.Clear();
                } 
            }
            else Console.WriteLine("Ошибка. Введено не числовое значение");           
        }

    }
}



