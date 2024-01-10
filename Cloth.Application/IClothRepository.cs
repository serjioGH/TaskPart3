namespace Cloth.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClothRepository
    {
        List<Domain.Cloth> GetAllCloths();
    }
}
