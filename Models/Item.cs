using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        [Key] // primary key
        public int id { get; set; }

        [Required]  
        public string Borrower { get; set; }
        [Required]
        public string Lender { get; set; }
        [Required]
        public string ItemName { get; set; }

    }
}
