using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor.TextHandler
{
     public class Performer: IPerformer
    {
        public ITextModelCreator creator { get; set; } = new TextModelCreator();
        public ITextModel textModel { get; set; } = new TextModel();
        public void Perform()
        {            
            textModel = creator.CreateTextModel();
        }
        
        public List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel)
        {
            var result = textModel.Text.Where(x => x.SentenceElements.
             Where(x => x is Word).Count() > 0).OrderBy(x=>x.SentenceElements.Where(x=>(x is Word)).Count()).ToList();//Все предложения заданного текста в порядке возрастания количества слов в каждом из них.



            return result;
           
        }

    }
}
