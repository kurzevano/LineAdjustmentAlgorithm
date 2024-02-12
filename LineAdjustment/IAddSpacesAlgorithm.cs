using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineAdjustment;

/// <summary>
/// Алгоритм добавления пробелов между словами до достижения указанной длины строки.
/// </summary>
public interface IAddSpacesAlgorithm
{
    /// <summary>
    /// Добавляет пробелы между словами.
    /// </summary>
    /// <param name="listWords">Список слов, между которыми нужно добавить пробелы.</param>
    /// <param name="lineWidth">Длина результирующей строки.</param>
    /// <param name="resultBuilder">StringBuilder, в который добавляются слова, разделённые пробелами.</param>
    void AddSpaces(IList<string> listWords, int lineWidth, StringBuilder resultBuilder);
}

public class AddSpacesAlgorithm : IAddSpacesAlgorithm
{
    /// <summary>
    /// Добавляет пробелы между словами.
    /// Расстояние между словами заполняется равным количеством пробелов, если же это не возможно, то добавляем
    /// еще по пробелу между словами слева направо. Если в строке помещается только 1 слово, то строка дополняется
    ///  пробелами справа.
    /// </summary>
    /// <param name="listWords">Список слов.</param>
    /// <param name="lineWidth">Длина результирующей строки.</param>
    /// <param name="resultBuilder">StringBuilder, в который добавляются слова, разделённые пробелами.</param>
    /// <exception cref="Exception">Исключение, если одно из слов превышает заданную длниу.</exception>
    public void AddSpaces(IList<string> listWords, int lineWidth, StringBuilder resultBuilder)
    {
        if (listWords.Count == 0)
        {
            return;
        }

        if (listWords.Sum(s => s.Length) > lineWidth)
        {
            throw new Exception($"String {string.Join(' ', listWords)} is too long");
        }

        if (listWords.Count == 1)
        {
            resultBuilder.Append(listWords[0]).Append(' ', lineWidth - listWords[0].Length);
            return;
        }

        var totalSpacesToAdd = lineWidth - listWords.Sum(s => s.Length);
        var wordGapsCount = listWords.Count - 1;
        var gapSpacesCount = totalSpacesToAdd / wordGapsCount; // number of whitespaces to add after each word
        var gapsWithExtraSpacesCount = totalSpacesToAdd % wordGapsCount; // number of words after which extra whitespace is needed
        int i;
        for (i = 0; i < listWords.Count - 1; i++)
        {
            resultBuilder.Append(listWords[i]).Append(' ', (i < gapsWithExtraSpacesCount) ? gapSpacesCount + 1 : gapSpacesCount);
        }

        resultBuilder.Append(listWords[i]);
    }
}