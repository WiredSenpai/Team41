using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? CreatedDate { get; set; }
        public string? Status { get; set; }
    
    }
}
