using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public String? SuplierEmail {get; set;}
        public String? SuplierContact {get; set;}

        public string? Status { get; set; }
   }
}