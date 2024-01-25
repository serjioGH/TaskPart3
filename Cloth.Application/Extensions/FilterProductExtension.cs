namespace Cloth.Application.Extensions;

using Cloth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public static class FilterProductExtension
{
    /// <summary>
    /// Splits the descriptions of the items with "." and " " and finds the most common words skipping the first 5
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<string> GetCommonWords(this List<Cloth> list)
    {
        string allDescriptions = string.Empty;
        foreach (var item in list)
        {
            allDescriptions = allDescriptions + item.Description.ToLower() + " ";
        }

        string[] splitWords = allDescriptions.Split(new string[] { " ", "." }, StringSplitOptions.RemoveEmptyEntries);
        var commonWords = splitWords.ToList().GroupBy(e => e.ToLower()).Select(g => new { Value = g.Key, Count = g.Count() }).OrderBy(e => e.Value).OrderByDescending(e => e.Count).Skip(5).Take(10);

        return commonWords.Select(g => g.Value).ToList();
    }

    /// <summary>
    /// Filters the description of the given cloths surrounding the given highlight words with tag <em></em>
    /// </summary>
    /// <param name="highlights">Highlight to look for</param>
    /// <param name="list">List of items whose Description needs to be filtered</param>
    /// <returns></returns>
    public static List<Cloth> FilterWithHighlights(this List<Cloth> list, List<string> highlights)
    {
        foreach (var cloth in list)
        {
            foreach (var currentHighlight in highlights)
            {
                if (cloth.Description.Contains(currentHighlight))
                {
                    cloth.Description = cloth.Description.Replace(currentHighlight, "<em>" + currentHighlight + "</em>");
                }
            }

        }
        return list;
    }

    /// <summary>
    /// Gets the unique sizes of cloths
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<string> GetUniqueSizes(this List<Cloth> list)
    {
        List<string> sizes = new List<string>();
        foreach (var cloth in list)
        {
            foreach (var currentSize in cloth.Sizes)
            {
                if (!sizes.Contains(currentSize))
                {
                    sizes.Add(currentSize);
                }
            }
        }

        return sizes;
    }

    public static List<Cloth> MinPriceFilter(this List<Cloth> cloths, decimal? minPrice)
    {
        if (minPrice.HasValue)
        {
            return cloths.Where(p => p.Price >= minPrice.Value).ToList();
        }

        return cloths;
    }

    public static List<Cloth> MaxPriceFilter(this List<Cloth> cloths, decimal? maxPrice)
    {
        if (maxPrice.HasValue)
        {
            return cloths.Where(p => p.Price <= maxPrice.Value).ToList();
        }

        return cloths;
    }

    public static List<Cloth> SizeFilter(this List<Cloth> items, string? size)
    {
        if (string.IsNullOrEmpty(size))
        {
            return items;
        }

        return items.Where(p => p.Sizes.Contains(size)).ToList();
    }
}

