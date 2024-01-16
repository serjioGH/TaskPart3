namespace Cloth.API.Controllers
{
    using Cloth.Application;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ClothsController : ControllerBase
    {

        private readonly IClothService clothService;

        public ClothsController(IClothService clothService)
        {
            this.clothService = clothService;
        }
        // GET: api/<ClothsController>
        [HttpGet]
        public ActionResult Get(int? MinPrice, int? MaxPrice, string? Size, string? Highlight)
        {
            var allItems = this.clothService.GetAllCloths();

            var filter = new Filter();
            filter.MinPrice = allItems.Select(p => p.Price).Min();
            filter.MaxPrice = allItems.Select(p => p.Price).Max();
            filter.Sizes = this.clothService.GetUniqueSizes(allItems);
            filter.CommonWords = this.clothService.GetCommonWords(allItems);
            var filtered = new List<Domain.Cloth>();
            if (MinPrice != null)
            {
                allItems = allItems.Where(cl => cl.Price > MinPrice).ToList();
            }

            if (MaxPrice != null)
            {
                allItems = allItems.Where(cl => cl.Price < MaxPrice).ToList();
            }

            if (Size != null)
            {
                allItems = allItems.Where(cl => cl.Sizes.Contains(Size)).ToList();
            }

            if (Highlight != null)
            {
                List<string> allHighlights = this.clothService.GetHighlights(Highlight);
                allItems = this.clothService.FilterWithHighlights(allHighlights, allItems);
            }

            return Ok(new { filter = filter, products = allItems});
        }

    }
}
