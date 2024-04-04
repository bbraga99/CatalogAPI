using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public ProductsController(AppDbContext? context)
        {
             _context =  context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.AsNoTracking().ToListAsync();  
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);    
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {

            if (product is null) return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();


            return new CreatedAtRouteResult("GetProduct",
                     new { id = product.ProductId}, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Product> Put(int id, Product product)
        {
            if(id != product.ProductId)
            {
                return NotFound();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if(product is null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return Ok("Product deleted");
        }
    }
}
