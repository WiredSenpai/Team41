using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
    public class CompanyDetails
    {
        [Key]
        public int CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public string? Logo { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Surburb { get; set; }
        public string? City { get; set; }
        public int? code { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }

    }
}
