using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyCRUD.API.DTOs.TagDTOs;
using OneToManyCRUD.Core.Entities;
using OneToManyCRUD.DAL.Context;

namespace OneToManyCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public TagController(IMapper mapper, AppDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _db.Tags
                .Include(t => t.ProductTags)
                .ThenInclude(pt => pt.Product)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null) return NotFound("tag tapilmadi");

            var result = new
            {
                tag.Id,
                tag.Name,
                tag.ProductTags
            };

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _db.Tags
                .Include(t => t.ProductTags)
                .ThenInclude(pt => pt.Product)
                .ToListAsync();

            var result = tags.Select(tag => new
            {
                tag.Id,
                tag.Name,
                Products = tag.ProductTags.Select(pt => new
                {
                    pt.Product.Name
                }).ToList()
            }).ToList();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagDTO createTagDto)
        {
            var tag = new Tags
            {
                Name = createTagDto.Name
            };

            if (createTagDto.ProductIds != null && createTagDto.ProductIds.Any())
            {
                tag.ProductTags = createTagDto.ProductIds
                    .Select(productId => new ProductTag
                    {
                        ProductId = productId
                    }).ToList();
            }

            await _db.Tags.AddAsync(tag);
            await _db.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, tag);
        }



    }
}
