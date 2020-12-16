using System.Collections.Generic;

namespace TextProcessor
{
    public interface ITextModel
    {
        List<ISentence> Text { get; set; }
    }
}