namespace Cloth.API.Controllers
{
    using Cloth.Application;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CLothsController : ControllerBase
    {

        private readonly IClothService clothService;

        public CLothsController(IClothService clothService)
        {
            this.clothService = clothService;
        }
        // GET: api/<ClothsController>
        [HttpGet]
        public ActionResult<IList<Domain.Cloth>> Get()
        {
            return Ok(this.clothService.GetAllCloths());
        }

    }
}
