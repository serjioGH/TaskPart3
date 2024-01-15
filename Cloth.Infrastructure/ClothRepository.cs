using Cloth.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cloth.Infrastructure
{
    public class ClothRepository : IClothRepository
    {
        public string jsonPath = "https://run.mocky.io/v3/97aa328f-6f5d-458a-9fa4-55fe58eaacc9";
        public static List<Domain.Cloth> lstCloths = new List<Domain.Cloth>();

        public List<Domain.Cloth> GetAllCloths()
        {
            var reader = new ReadJsonFromUrl(jsonPath);
            var list = reader.UseReadJson();
            return list;
        }
    }
}
