using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public string? AddressLine1 { get; set; }
        public string? Surburb { get; set; }
        public string? City { get; set; }
        public int? code { get; set; }
        public string? Status { get; set; }
    }
}
