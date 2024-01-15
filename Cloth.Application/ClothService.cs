using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloth.Application
{
    public class ClothService : IClothService
    {

        private readonly IClothRepository clothRepository;
        public ClothService(IClothRepository memberRepository)
        {
            this.clothRepository = memberRepository;
        }

        public List<Domain.Cloth> GetAllCloths()
        {
            return this.clothRepository.GetAllCloths();
        }

        public List<string> GetHighlights(string highlight)
        {
            var highlights = new List<string>();
            if (highlight.Contains(','))
            {
                highlights = highlight.Split(',').ToList();
            }
            else
            {
                highlights.Add(highlight);
            }

            return highlights;
        }

        public List<string> GetUniqueSizes(List<Domain.Cloth> list)
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

        public List<Domain.Cloth> FilterWithHighlights(List<string> highlights, List<Domain.Cloth> list)
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
