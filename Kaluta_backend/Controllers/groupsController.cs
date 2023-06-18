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
//    public class groupsController : Controller
//    {
//        private readonly universityContext _context;

//        public groupsController(universityContext context)
//        {
//            _context = context;
//        }

//        // GET: groups
//        public async Task<IActionResult> Index()
//        {
//              return _context.group != null ? 
//                          View(await _context.group.ToListAsync()) :
//                          Problem("Entity set 'universityContext.group'  is null.");
//        }

//        // GET: groups/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.group == null)
//            {
//                return NotFound();
//            }

//            var @group = await _context.group
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (@group == null)
//            {
//                return NotFound();
//            }

//            return View(@group);
//        }

//        // GET: groups/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: groups/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Title,Department")] group @group)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(@group);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(@group);
//        }

//        // GET: groups/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.group == null)
//            {
//                return NotFound();
//            }

//            var @group = await _context.group.FindAsync(id);
//            if (@group == null)
//            {
//                return NotFound();
//            }
//            return View(@group);
//        }

//        // POST: groups/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Department")] group @group)
//        {
//            if (id != @group.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(@group);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!groupExists(@group.Id))
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
//            return View(@group);
//        }

//        // GET: groups/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.group == null)
//            {
//                return NotFound();
//            }

//            var @group = await _context.group
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (@group == null)
//            {
//                return NotFound();
//            }

//            return View(@group);
//        }

//        // POST: groups/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.group == null)
//            {
//                return Problem("Entity set 'universityContext.group'  is null.");
//            }
//            var @group = await _context.group.FindAsync(id);
//            if (@group != null)
//            {
//                _context.group.Remove(@group);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool groupExists(int id)
//        {
//          return (_context.group?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Kaluta_backend.Models;
using static System.Reflection.Metadata.BlobBuilder;
using Kaluta_backend.Models;

namespace Kaluta_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class groupsController : ControllerBase
    {
        private readonly universityContext _context;

        //Authors[] Authors = new Authors[]
        // {
        // new Authors { Id = 1, Surname = "Ostin", Name = "Jane", Yearbirth = 1775},
        // new Authors { Id = 2, Surname = "Bulgakov", Name = "Mihail", Yearbirth = 1891}
        // };


        public groupsController(universityContext context)
        {
            _context = context;
        }

        // GET: api/group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<group>>> Getgroup()
{
if (_context.group == null)
{
return NotFound();
    }
return await _context.group.ToListAsync();
}

        //// GET: api/group/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Authors» GetAuthors(int id)
        //{
        // if (_context.Authors == null)
        // {
        // return NotFound();
        // }
        // var authors = await _context.Authors.FindAsync(id);

        // if (authors == null)
        // {
        // return NotFound();
        // }

        // return authors;
        //}

        // PUT: api/group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
public async Task<IActionResult> Putgroup(int id, group? group)
{
    if (id != group.Id)
    {
        return BadRequest();
    }

    _context.Entry(group).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!groupExists(id))
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

        // POST: api/group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
public async Task<ActionResult<group>> Postgroup(group group)
{
    if (_context.group == null)
    {
        return Problem("Entity set 'universityContext.groups' is null.");
    }
    
    _context.group.Add(group);
    await _context.SaveChangesAsync();

    return CreatedAtAction("Getgroup", new { id = group.Id }, group);
}

        // DELETE: api/group/5
        [HttpDelete("{id}")]
public async Task<IActionResult> Deletegroup(int id)
{
    if (_context.group == null)
    {
        return NotFound();
    }
    var group = await _context.group.FindAsync(id);
    if (group == null)
    {
        return NotFound();
    }

    _context.group.Remove(group);
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool groupExists(int id)
{
    return (_context.group?.Any(e => e.Id == id)).GetValueOrDefault();
}

        // GET: api/group/Department
        [HttpGet("{Department}")]
public async Task<ActionResult<IEnumerable<group>>> GetGroupByDepartment(string Department)
{
    if (_context.group == null)
    {
        return NotFound();
    }
    var groupss = await _context.group
    .Where(a => a.Department == Department)
    .ToListAsync();

    if (groupss == null)
    {
        return NotFound();
    }

    return groupss;
}
}
}
