using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineAdjustment;

public interface IAddSpacesAlgorithm
{
    string AddSpaces(IList<string> listWords, int lineWidth);
}

public class AddSpacesAlgorithm : IAddSpacesAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listWords"></param>
    /// <param name="lineWidth"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public string AddSpaces(IList<string> listWords, int lineWidth)
    {
        if (!listWords.Any())
        {
            return string.Empty;
        }

        if (listWords.Sum(s => s.Length) > lineWidth)
        {
            throw new Exception($"String {string.Join(' ', listWords)} is too long");
        }

        if (listWords.Count == 1)
        {
            return listWords[0] + new string(' ', lineWidth - listWords[0].Length);
        }

        var spacesToAdd = lineWidth - listWords.Sum(s => s.Length);
        var wordGapsCount = listWords.Count - 1;
        var yesSpaces = spacesToAdd / wordGapsCount; // number of whitespaces to add after each word
        var extraSpaces = spacesToAdd % wordGapsCount; // number of words after which extra whitespace is needed
        var resultBuilder = new StringBuilder(lineWidth);
        int i;
        for (i = 0; i < listWords.Count - 1; i++)
        {
            resultBuilder.Append(listWords[i]).Append(' ', (i < extraSpaces) ? yesSpaces + 1 : yesSpaces);
        }

        resultBuilder.Append(listWords[i]);
        return resultBuilder.ToString();
    }
}