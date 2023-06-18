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
//    public class studentsController : Controller
//    {
//        private readonly universityContext _context;

//        public studentsController(universityContext context)
//        {
//            _context = context;
//        }

//        // GET: students
//        public async Task<IActionResult> Index()
//        {
//              return _context.student != null ? 
//                          View(await _context.student.ToListAsync()) :
//                          Problem("Entity set 'universityContext.student'  is null.");
//        }

//        // GET: students/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.student == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.student
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // GET: students/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: students/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Name,Surname,YearOfBirth")] student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(student);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: students/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.student == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.student.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // POST: students/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,YearOfBirth")] student student)
//        {
//            if (id != student.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(student);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!studentExists(student.ID))
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
//            return View(student);
//        }

//        // GET: students/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.student == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.student
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.student == null)
//            {
//                return Problem("Entity set 'universityContext.student'  is null.");
//            }
//            var student = await _context.student.FindAsync(id);
//            if (student != null)
//            {
//                _context.student.Remove(student);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool studentExists(int id)
//        {
//          return (_context.student?.Any(e => e.ID == id)).GetValueOrDefault();
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

namespace Kaluta_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        private readonly universityContext _context;

        //Books[] Books = new Books[]
        //{
        // new Books { ID = 1, Title = "Pride and Prejudice", Year = 1813, ShortDesc = "Romantic story"},
        // new Books { ID = 2, Title = "The Master and Margarita", Year = 1966, ShortDesc = "Fantastic and ironically philosophical"}

        //};

        public studentsController(universityContext context)
        {
            _context = context;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<student>>> Getstudent()
{
if (_context.student == null)
{
return NotFound();
    }
            List<student> s = await _context.student.Include(s => s.group).ToListAsync();

return s;
        }

        //// GET: api/student/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Books» GetBooks(int id)
        //{
        // if (_context.Books == null)
        // {
        // return NotFound();
        // }
        // var books = await _context.Books.FindAsync(id);
        // // var bookss = _context.Books.Include(b => b.Title).Where(r => r.ID == id).ToList();

        // if (books == null)
        // {
        // return NotFound();
        // }

        // return books;
        //}

        //[HttpGet("GetRequestsByTitle")]
        //public async Task<ActionResult<IEnumerable<Books»> GetRequests(string Title)
        //{
        // if (_context.Books == null)
        // {
        // return NotFound();
        // }

        // //var result = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Title == Title);
        // var results = await _context.Books
        // .Where(b => b.Books.Title == Title)
        // .Include(b => b.Author)
        // .ToListAsync();

        // if (results == null)
        // {
        // return NotFound();
        // }

        // return results;
        //}


        // PUT: api/student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
public async Task<IActionResult> Putstudent(int id, student student)
{
    if (id != student.ID)
    {
        return BadRequest();
    }

    _context.Entry(student).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!studentExists(id))
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

        // POST: api/student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
public async Task<ActionResult<student>> Poststudent(student student)
{
    if (_context.student == null)
    {
        return Problem("Entity set 'universityContext.students' is null.");
    }
    
    _context.student.Add(student);
    await _context.SaveChangesAsync();

    return CreatedAtAction("Getstudent", new { id = student.ID }, student);
}

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletestudent(int id)
        {
            if (_context.student == null)
            {
                return NotFound();
            }
            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool studentExists(int id)
{
    return (_context.student?.Any(e => e.ID == id)).GetValueOrDefault();
}


        //// GET: api/student/Year
        //[HttpGet("{Year}")]
        //public async Task<ActionResult<IEnumerable<Books»> GetBooksByTitle(int Year)
        //{
        // if (_context.Books == null)
        // {
        // return NotFound();
        // }
        // var bookss = await _context.Books
        // .Where(b => b.Year == Year)
        // .ToListAsync();

        // if (bookss == null)
        // {
        // return NotFound();
        // }

        // return bookss;
        //}


        // GET: api/student/group
        [HttpGet("{group}")]
public async Task<ActionResult<IEnumerable<student>>> GetstudentBygroup(group group)
{
    if (_context.student == null)
    {
        return NotFound();
    }
    var studentss = await _context.student
    .Where(b => b.group == group)
    .ToListAsync();

    if (studentss == null)
    {
        return NotFound();
    }

    return studentss;
}
}
}






