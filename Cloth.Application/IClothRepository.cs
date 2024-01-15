namespace Cloth.Application
{
    using System;
    using System.Collections.Generic;

    public interface IClothRepository
    {
        List<Domain.Cloth> GetAllCloths();
    }
}
