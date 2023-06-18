//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Kaluta_backend.Models;

//namespace Kaluta_backend.Controllers
//{
//    public class universitiesController : Controller
//    {
//        private readonly universityContext _context;

//        public universitiesController(universityContext context)
//        {
//            _context = context;
//        }

//        // GET: universities
//        public async Task<IActionResult> Index()
//        {
//              return _context.university != null ? 
//                          View(await _context.university.ToListAsync()) :
//                          Problem("Entity set 'universityContext.university'  is null.");
//        }

//        // GET: universities/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.university == null)
//            {
//                return NotFound();
//            }

//            var university = await _context.university
//                .FirstOrDefaultAsync(m => m.id == id);
//            if (university == null)
//            {
//                return NotFound();
//            }

//            return View(university);
//        }

//        // GET: universities/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: universities/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("id")] university university)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(university);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(university);
//        }

//        // GET: universities/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.university == null)
//            {
//                return NotFound();
//            }

//            var university = await _context.university.FindAsync(id);
//            if (university == null)
//            {
//                return NotFound();
//            }
//            return View(university);
//        }

//        // POST: universities/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("id")] university university)
//        {
//            if (id != university.id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(university);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!universityExists(university.id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(university);
//        }

//        // GET: universities/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.university == null)
//            {
//                return NotFound();
//            }

//            var university = await _context.university
//                .FirstOrDefaultAsync(m => m.id == id);
//            if (university == null)
//            {
//                return NotFound();
//            }

//            return View(university);
//        }

//        // POST: universities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.university == null)
//            {
//                return Problem("Entity set 'universityContext.university'  is null.");
//            }
//            var university = await _context.university.FindAsync(id);
//            if (university != null)
//            {
//                _context.university.Remove(university);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool universityExists(int id)
//        {
//          return (_context.university?.Any(e => e.id == id)).GetValueOrDefault();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kaluta_backend.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Kaluta_backend.Interfaces;

namespace Kaluta_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class universitiesController : ControllerBase
    {
        private readonly universityContext _context;

        public universitiesController(universityContext context)
        {
            _context = context;
        }

        // GET: api/university
        //[HttpGet]
        // public async Task<ActionResult<IEnumerable<Library»> GetLibrary()
        // {
        // if (_context.Library == null)
        // {
        // return NotFound();
        // }
        // return await _context.Library.Include(a => a.Surname).ToListAsync();
        // }

        // GET: api/Library/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<university>> Getuniversity(int id)
        //{
        //if (_context.university == null)
        //{
        //return NotFound();
        //    }
        //    var University = await _context.university.FindAsync(id);

        //if (University == null)
        //{
        //return NotFound();
        //}

        //return University;
        //}
        //GET: api/Library
        [HttpGet]
        public async Task<ActionResult<IEnumerable<university>>> Getuniversity()
{
if (_context.university == null)
{
return NotFound();
    }
return await _context.university.Include(uni => uni.groups).ToListAsync();
}

// PUT: api/university/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task<IActionResult> Putuniversity(int id, university University)
{
    if (id != University.id)
    {
        return BadRequest();
    }

    _context.Entry(University).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!universityExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}

        // POST: api/university
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
public async Task<ActionResult<university>> Postuniversity(university University)
{
    if (_context.university == null)
    {
        return Problem("Entity set 'universityContext.university' is null.");
    }
    
    _context.university.Add(University);
    await _context.SaveChangesAsync();

    return CreatedAtAction("Getuniversity", new { id = University.id }, University);
}

        // DELETE: api/university/5
        [HttpDelete("{id}")]
public async Task<IActionResult> Deleteuniversity(int id)
{
    if (_context.university == null)
    {
        return NotFound();
    }
    var University = await _context.university.FindAsync(id);
    if (University == null)
    {
        return NotFound();
    }

    _context.university.Remove(University);
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool universityExists(int id)
{
    return (_context.university?.Any(e => e.id == id)).GetValueOrDefault();
}


////мои функции

//[HttpPut()]
//[Route("Addgroup")]
//[Authorize(Roles = "user")]
//public async Task<IActionResult> Addgroup(int dayId, int groupId)
//{
//    var Group = _context.group.Where(a => a.Id == groupId).FirstOrDefault();

//    var University = _context.group.Where(uni => uni.Id == dayId).FirstOrDefault();

//    University.Addgroup(Group);
//    _context.Entry(University).State = EntityState.Modified;
//    _context.SaveChanges();

//    return NoContent();
//}

//[HttpDelete()]
//[Route("DeleteAuthors")]
//[Authorize(Roles = "user")]

//public async Task<IActionResult> DeleteAuthors(int dayId, int AuthorsId)
//{
// var authors = _context.Authors.Where(a => a.Id == AuthorsId).FirstOrDefault();

// var library = _context.Library.Where(lib => lib.Id == dayId).FirstOrDefault();

// library.DeleteAuthors(authors);
// _context.Entry(library).State = EntityState.Modified;
// _context.SaveChanges();

// return NoContent();
//}


}

}
