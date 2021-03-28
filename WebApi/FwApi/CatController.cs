using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;

namespace FwApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        //private readonly AppDataDbContext _context;

        //public CatController(AppDataDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Cat2
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        //{
        //    return await _context.Category.ToListAsync();
        //}

        //// GET: api/Cat2/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //    var category = await _context.Category.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        //// PUT: api/Cat2/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Cat2
        //[HttpPost]
        //public async Task<ActionResult<Category>> PostCategory(Category category)
        //{
        //    _context.Category.Add(category);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        //}

        //// DELETE: api/Cat2/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Category>> DeleteCategory(int id)
        //{
        //    var category = await _context.Category.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Category.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return category;
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _context.Category.Any(e => e.ID == id);
        //}
    }
}
