using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloth.Application
{
    public class ClothService : IClothService
    {
        private readonly IClothRepository clothRepository;
        private readonly ILogger<ClothService> _logger;
        public ClothService(IClothRepository memberRepository, ILogger<ClothService> logger)
        {
            _logger = logger;
            this.clothRepository = memberRepository;
        }

        /// <summary>
        /// Gets all Cloths fro mthe repository
        /// </summary>
        /// <returns></returns>
        public List<Domain.Cloth> GetAllCloths()
        {
            return this.clothRepository.GetAllCloths();
        }

        /// <summary>
        /// Splits the input to form list of different highlights
        /// </summary>
        /// <param name="highlight"></param>
        /// <returns></returns>
        public List<string> GetHighlights(string highlight)
        {
            var highlights = new List<string>();
            if (highlight.Contains(','))
            {
                _logger.LogInformation("Multiple highlights detected in " + highlight);
                highlights = highlight.Split(',').ToList();
            }
            else
            {
                highlights.Add(highlight);
            }

            return highlights;
        }

        /// <summary>
        /// Gets the unique sizes of cloths
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<string> GetUniqueSizes(List<Domain.Cloth> list)
        {
            List<string> sizes = new List<string>();
            foreach (var cloth in list)
            {
                foreach (var currentSize in cloth.Sizes)
                {
                    if (!sizes.Contains(currentSize))
                    {
                        _logger.LogInformation("Unique size found" + currentSize);
                        sizes.Add(currentSize);
                    }
                }
            }

            return sizes;
        }

        /// <summary>
        /// Filters the description of the given cloths surrounding the given highlight words with tag <em></em>
        /// </summary>
        /// <param name="highlights">Highlight to look for</param>
        /// <param name="list">List of items whose Description needs to be filtered</param>
        /// <returns></returns>
        public List<Domain.Cloth> FilterWithHighlights(List<string> highlights, List<Domain.Cloth> list)
        {
            foreach (var cloth in list)
            {
                foreach (var currentHighlight in highlights)
                {
                    if (cloth.Description.Contains(currentHighlight))
                    {
                        _logger.LogInformation("Filtered highlight: " + currentHighlight + " in description of " + cloth.Title);
                        cloth.Description = cloth.Description.Replace(currentHighlight, "<em>" + currentHighlight + "</em>");
                    }
                }

            }
            return list;
        }

        /// <summary>
        /// Splits the descriptions of the items with "." and " " and finds the most common words skipping the first 5
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<string> GetCommonWords(List<Domain.Cloth> list)
        {
            string allDescriptions = string.Empty;
            foreach (var item in list)
            {
                allDescriptions = allDescriptions + item.Description.ToLower() + " ";
            }

            string[] splitWords = allDescriptions.Split(new string[] { " ", "." }, StringSplitOptions.RemoveEmptyEntries);
            var commonWords = splitWords.ToList().GroupBy(e => e).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(e => e.Count).Skip(5).Take(10);

            return commonWords.Select(g => g.Value).ToList();
        }

    }
}
