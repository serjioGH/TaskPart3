using Cloth.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloth.Infrastructure
{
    public class ClothRepository : IClothRepository
    {
        public static List<Domain.Cloth> lstCloths = new List<Domain.Cloth>();

        public List<Domain.Cloth> GetAllCloths()
        {
            return lstCloths;
        }
    }
}
