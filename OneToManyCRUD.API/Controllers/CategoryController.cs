using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using OneToManyCRUD.API.DTOs.CategoryDTOs;
using OneToManyCRUD.Business.DTOs.CategoryDTOs;
using OneToManyCRUD.Core.Entities;
using OneToManyCRUD.DAL.Context;

namespace OneToManyCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound("bele categoriya yoxdu");

            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _dbContext.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO categoryDTO)
        {
            var newCategory = _mapper.Map<Category>(categoryDTO);

            await _dbContext.Categories.AddAsync(newCategory);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, newCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound("bele categoriya yxodur");

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return Ok("category silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest("id dzugun deyil");

            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound("bele category yoxdu");

            _mapper.Map(categoryDTO, category);

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();

            return Ok(category);
        }
    }

}
