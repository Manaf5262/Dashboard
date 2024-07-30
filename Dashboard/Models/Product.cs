using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Insert Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Insert Discription")]
        [StringLength(50)]
        public string? Description { get; set; }





    }
}
