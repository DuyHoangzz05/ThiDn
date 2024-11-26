public class Rental
{
    internal int Id;

    public int RentalId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double TotalAmount { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<RentalDetail>? RentalDetails { get; set; }
}