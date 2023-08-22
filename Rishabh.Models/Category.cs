using System.ComponentModel.DataAnnotations;

namespace RishabhWeeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Required(ErrorMessage ="This Field Is Required")]
        [Range(1,100,ErrorMessage ="Display Order Must be in Range Of 1 to 100 !!!")]
        public int DisplayOrder { get; set; } 
    }
}
