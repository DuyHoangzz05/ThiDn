using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the connection to the database using MySQL
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30)))
);

// Add services for MVC (including TempData support)
builder.Services.AddControllersWithViews(); // This registers MVC services including TempData
builder.Services.AddRazorPages();  // Optionally add Razor Pages if you're using them

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use MVC routing and authorization
app.UseAuthorization();

// Map controllers and Razor Pages (if you have them)
app.MapControllers();
app.MapRazorPages(); // If you're using Razor Pages, add this line

app.Run();
