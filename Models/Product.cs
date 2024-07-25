using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public int SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
        public string? Status { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? ModelNumber { get; set; }
        public String? Capacity { get; set; }
        public string? EnergyRating { get; set; }
        public string? Dimensions { get; set; }
        public string? Warranty { get; set; }
        public string? ImgUrl { get; set; }
        public string? ImgThumbnail { get; set; }
        public string? ImageFile { get; set; }

        [NotMapped]
        public IFormFile? ImageFile1 { get; set; }

        [NotMapped]
        public IFormFile? ImageFile2 { get; set; }
    }
}

