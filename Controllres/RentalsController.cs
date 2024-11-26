using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : Controller
{
    private readonly DBContext _context;

    public RentalsController(DBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RentBook(RentalRequest rentalRequest)
    {
        var rental = new Rental
        {
            CustomerId = rentalRequest.CustomerId,
            RentalDate = rentalRequest.RentalDate,
            ReturnDate = rentalRequest.ReturnDate,
            TotalAmount = (double)(rentalRequest.Quantity * rentalRequest.PricePerDay)
        };

        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        var rentalDetail = new RentalDetail
        {
            RentalId = rental.Id,
            ComicBookId = rentalRequest.ComicBookId,
            Quantity = rentalRequest.Quantity,
            PricePerDay = (double)rentalRequest.PricePerDay
        };

        _context.RentalDetails.Add(rentalDetail);
        await _context.SaveChangesAsync();

        return RedirectToAction("RentalHistory");
    }
}

public class RentalRequest
{
    public int CustomerId { get; set; }
    public int ComicBookId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerDay { get; set; }
}
