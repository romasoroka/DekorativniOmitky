using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebSiteRazorPages.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 20, ErrorMessage = "Range is between 1-20")]
        public int DisplayOrder { get; set; }
    }   
}
