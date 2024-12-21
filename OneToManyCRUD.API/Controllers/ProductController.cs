using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyCRUD.API.DTOs.ProductDTOs;
using OneToManyCRUD.Core.Entities;
using OneToManyCRUD.DAL.Context;

namespace OneToManyCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _db.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound("mehsul tapilmadu");

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _db.Products
                .Include(p => p.Category)
                .ToList();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            var category = await _db.Categories.FindAsync(dto.CategoryId);
            if (category == null) return NotFound("bele bir kateqoriya yoxdur!");

            var newProduct = _mapper.Map<Product>(dto);
            newProduct.Category = category;

            _db.Products.Add(newProduct);
            await _db.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, newProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound("mehsul tapilmadi");

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return Ok("mehsul silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDTO dto)
        {
            if (id != dto.Id) return BadRequest("bele id-li mehsul yoxdu");

            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound("mehsul yoxdu");

            _mapper.Map(dto, product);

            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            return Ok(product);
        }
    }
}
