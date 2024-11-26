using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ReportsController : Controller
{
    private readonly DBContext _context;

    public ReportsController(DBContext context)
    {
        _context = context;
    }

    // Generate report of rentals between dates
    public async Task<IActionResult> BookRentReport(DateTime startDate, DateTime endDate)
    {
        var rentals = await _context.Rentals
            .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
            .Include(r => r.RentalDetails)
            .ThenInclude(rd => rd.ComicBook)
            .Include(r => r.Customer)
            .ToListAsync();

        return View(rentals);
    }
}
