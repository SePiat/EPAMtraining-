using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextProcessor.ReaderWriter;

namespace TextProcessor.TextHandler
{
     public class Performer: IPerformer
    {
        public ITextModelCreator Creator { get; set; } = new TextModelCreator();
        public ITextModel TextModel { get; set; } = new TextModel();
        public void Perform()
        {            
            TextModel = Creator.CreateTextModel();
        }
        
        public List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel)
        {
            var result = textModel.Text.Where(x => x.SentenceElements.
             Where(x => x is Word).Count() > 0).OrderBy(x=>x.SentenceElements.Where(x=>(x is Word)).Count()).ToList();//Все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            return result;           
        }


        public List<string> WordsSetLengthByQuestionableSentence(ITextModel textModel)
        {           
            
            List<string> listWords = new List<string>();
            List<string> listWordsDistinct = new List<string>();


            Console.WriteLine("Для поиска слов заданной длины в вопросительных предложениях задайте длину слова");
            bool iswordLengthSuccess = int.TryParse(Console.ReadLine(),out int wordLength);
            if (iswordLengthSuccess)
            {
                List<ISentence> questionableSentence = textModel.Text.
                Where(x => x.SentenceElements.
                Where(x => x.Symbols.
                Where(x => x.Character == '?').Count() > 0).Count() > 0).ToList(); //выбираем все вопросительные предложения                

                foreach (var sentence in questionableSentence)
                {
                    listWords.AddRange(sentence.SentenceElements.
                        Where(x => x is Word).
                        Where(x => x.Symbols.Count() == wordLength).
                        Select(x=>(Word)x).
                        Select(x=>x.stringWord));
                } //выбираем слова подходящей длины и добавляем их в колекцию слов
                
                listWordsDistinct.AddRange(listWords.Distinct());// добовляем в колекцию listWordsDistinct уникальные слова из listWords

            }
            else Console.WriteLine("Ошибка. Введено не числовое значение");
            

            return listWordsDistinct;
        }

    }
}
