namespace Projectdemo1.Models
{
    public class AddEmployee
    {
        public required string Name { get; set; }
        public required string Address { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
