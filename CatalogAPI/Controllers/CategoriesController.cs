using CatalogAPI.Context;
using CatalogAPI.Filters;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
         

        public CategoriesController(AppDbContext context /*ILogger logger*/)
        {
            _context = context;
           
        }


        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Category>>> GetProductsCategory()
        {
            return await _context.Categories.Include(p => p.Products).ToListAsync();
        }

        [HttpGet]
         
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            

            var categories = await _context.Categories.ToListAsync();

            if (categories is null) return null;

            return categories;
        }

        [HttpGet("{id:int}", Name ="GetCategories")]
        public ActionResult<IEnumerable<Category>> GetById(int id)
        {  
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category is null) return null;

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category) 
        {
            if (category is null) return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategories", 
                        new { id = category.CategoryId }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id,  Category category)
        {
            if (id != category.CategoryId) return null;

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok("Category updated");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if(category is null) return null;

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok("Category deleted");
        }
    }
}
