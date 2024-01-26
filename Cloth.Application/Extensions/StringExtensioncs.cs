namespace Cloth.Application.Extensions;

public static class StringExtensioncs
{
    /// <summary>
    /// Splits the input to form list of different highlights
    /// </summary>
    /// <param name="highlight"></param>
    /// <returns></returns>
    public static List<string> GetHighlights(this string? highlight)
    {
        var highlights = new List<string>();
        if (string.IsNullOrWhiteSpace(highlight))
        {
            return highlights;
        }
        else if (highlight.Contains(','))
        {
            highlights = highlight.Split(',').ToList();
        }
        else
        {
            highlights.Add(highlight);
        }

        return highlights;
    }
}

