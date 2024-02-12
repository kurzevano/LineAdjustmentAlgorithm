using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineAdjustment
{
    public class LineAdjustmentAlgorithmStringBuilder
    {
        private readonly IAddSpacesAlgorithm addSpacesAlgorithm;
        
        public LineAdjustmentAlgorithmStringBuilder(IAddSpacesAlgorithm addSpacesAlgorithm)
        {
            this.addSpacesAlgorithm = addSpacesAlgorithm;
        }
        
        public string Transform(string input, int lineWidth)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            
            var wordsArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            var listWords = new List<string>();

            int currentLineLength = 0;
            foreach (var word in wordsArray)
            {
                currentLineLength += word.Length;
                if (listWords.Any() && currentLineLength + listWords.Count - 1 >= lineWidth)
                {
                    if (result.Length > 0)
                    {
                        result.Append('\n');
                    }
                    
                    result.Append(this.addSpacesAlgorithm.AddSpaces(listWords, lineWidth));
                    listWords.Clear();
                    currentLineLength = word.Length;
                }
                
                listWords.Add(word);
            }

            if (listWords.Any())
            {
                if (result.Length > 0)
                {
                    result.Append('\n');
                }
                
                result.Append(this.addSpacesAlgorithm.AddSpaces(listWords, lineWidth));
            }

            return result.ToString();
        }
    }
}