using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    private readonly DBContext _context;

    public CustomersController(DBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            customer.RegisterDate = DateTime.Now;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ComicBooks");
        }
        return View(customer);
    }
}
