using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadget.Data.Data.CMS
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Required(ErrorMessage = "Set page link title")]
        [MaxLength(10, ErrorMessage = "Title must not be longer than 10 characters")]
        [Display(Name = "Title link")]
        public required string TitleLink { get; set; }

        [Required(ErrorMessage = "Set page title")]
        [MaxLength(30, ErrorMessage = "Title must not be longer than 30 characters")]
        [Display(Name = "Page title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Set page content")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Content")]
        public required string PageContent { get; set; }

        [Required(ErrorMessage = "Set position")]
        [Display(Name = "Display position")]
        public required int Position { get; set; }
    }
}
