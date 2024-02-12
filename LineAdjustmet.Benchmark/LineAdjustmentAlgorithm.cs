namespace LineAdjustment
{
    public class LineAdjustmentAlgorithm
    {
        public string Transform(string input, int lineWidth)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            
            var wordsArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            var listWords = new List<string>();
            foreach (var word in wordsArray)
            {
                var listWordsSum = listWords.Sum(s => s.Length);
                if (listWords.Any() && listWordsSum + word.Length + listWords.Count - 1 >= lineWidth)
                {
                    result.Add(AddSpaces(listWords, lineWidth));
                    listWords.Clear();
                }
                
                listWords.Add(word);
            }

            if (listWords.Any())
            {
                result.Add(AddSpaces(listWords, lineWidth));
            }

            return string.Join('\n', result);
        }

        private string AddSpaces(IList<string> listWords, int lineWidth)
        {
            if (!listWords.Any())
            {
                return string.Empty;
            }
            
            if (listWords.Count == 1)
            {
                return listWords[0] + new string(' ', lineWidth - listWords[0].Length);
            }

            var spacesToAdd = lineWidth - listWords.Sum(s => s.Length);
            var wordGapsCount = listWords.Count - 1;
            var yesSpaces = spacesToAdd / wordGapsCount;
            var extraSpaces = spacesToAdd % wordGapsCount;
                
            for (var i = 0; i < listWords.Count - 1; i++)
            {
                listWords[i] += new string(' ', (i < extraSpaces) ? yesSpaces + 1 : yesSpaces);
            }

            return string.Join("", listWords);
        }
    }
}