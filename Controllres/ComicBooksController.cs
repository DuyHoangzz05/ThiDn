using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ComicBooksController : Controller
{
    private readonly DBContext _context;

    public ComicBooksController(DBContext context)
    {
        _context = context;
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> Create(ComicBook comicBook)
    {
        if (ModelState.IsValid)
        {
            _context.Add(comicBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // Read
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.ComicBooks.ToListAsync());
    }

    // Edit (Update)
    [HttpGet("{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null)
        {
            return NotFound();
        }
        return View(comicBook);
    }
}
  
