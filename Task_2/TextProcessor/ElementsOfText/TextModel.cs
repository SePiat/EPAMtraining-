using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class TextModel: ITextModel
    {
        public List<ISentence> Text { get; set; } = new List<ISentence>();       
    }
}