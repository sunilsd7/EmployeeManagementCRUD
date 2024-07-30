namespace Projectdemo1.Models.Entities
{
    public class Employee

    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        public string? Phone { get; set; }

        public decimal? Salary { get; set; }
    }
 }



