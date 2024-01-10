using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
