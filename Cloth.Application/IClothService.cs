namespace Cloth.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClothService
    {
        List<Domain.Cloth> GetAllCloths();

        List<string> GetUniqueSizes(List<Domain.Cloth> list);

        List<string> GetCommonWords(List<Domain.Cloth> list);

        List<Domain.Cloth> FilterWithHighlights(List<string> highlights, List<Domain.Cloth> list);

        List<string> GetHighlights(string highlight);
    }
}
