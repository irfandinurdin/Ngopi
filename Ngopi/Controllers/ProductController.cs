using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ngopi.Helpers;
using Ngopi.Models;

namespace Ngopi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ProductController : Controller
    {
        private DataContext dbContext;
        public ProductController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("list-product")]
        public async Task<IActionResult> GetAll([FromBody] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.HargaMin, filter.HargaMax, filter.OrderBy, filter.Origin, filter.Species, filter.RoastLevel, filter.Tasted, filter.Processing);
            var pagedData = dbContext.Products.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize).AsQueryable();
            if (filter.OrderBy != 0)
            {
                switch (filter.OrderBy)
                {
                    case 1:
                        pagedData = pagedData.OrderBy(ob => ob.Name);
                        break;
                    case 2:
                        pagedData = pagedData.OrderBy(ob => ob.Brand);
                        break;
                    default:
                        pagedData = pagedData.OrderBy(ob => ob.Name);
                        break;
                }
            }
            if (filter.HargaMin < filter.HargaMax)
                pagedData = pagedData.Where(r => filter.HargaMin <= r.Price && filter.HargaMax >= r.Price);
            if (filter.Origin != null)
                pagedData = pagedData.Where(o => o.Origin != null && filter.Origin.Contains(o.Origin.Id));
            if (filter.Species != null)
                pagedData = pagedData.Where(s => s.Species != null && filter.Species.Contains(s.Species.Id));
            if (filter.RoastLevel != null)
                pagedData = pagedData.Where(rl => rl.RoastLevel != null && filter.RoastLevel.Contains(rl.RoastLevel.Id));
            if (filter.Tasted != null)
                pagedData = pagedData.Where(t => t.Tasted != null && filter.Tasted.Contains(t.Tasted.Id));
            if (filter.Processing != null)
                pagedData = pagedData.Where(p => p.Processing != null && filter.Processing.Contains(p.Processing.Id));

            var result = await pagedData.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                Price = x.Price,
                RateStar = x.RateStar,
                TotalRate = x.TotalRate,
                ImageName = x.ImageName,
                Origin = x.Origin,
                Species = x.Species,
                RoastLevel = x.RoastLevel,
                Tasted = x.Tasted,
                Processing = x.Processing,
            }).ToListAsync();
            var totalRecords = await dbContext.Products.CountAsync();
            return Ok(new PagedResponse<List<Product>>(result, validFilter.PageNumber, validFilter.PageSize));
        }
        [HttpGet("product/{id:Guid}")]
        public async Task<ActionResult<DetailProduct>> GetProductById(Guid id)
        {
            try
            {
                var result = await dbContext.DetailProducts.FirstOrDefaultAsync(x => x.Product != null && x.Product.Id == id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
