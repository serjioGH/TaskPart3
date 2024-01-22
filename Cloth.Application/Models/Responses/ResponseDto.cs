namespace Cloth.Application.Models.Responses
{
    using Cloth.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResponseDto
    {
        public Filter? Filter { get; set; }
        public IEnumerable<Cloth>? Products { get; set; }
    }
}
