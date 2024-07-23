using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadget.Data.Data.Shop
{
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }

        public Specification? Specification { get; set; }

        [Required(ErrorMessage = "Value must not be empty")]
        public string Value { get; set; }
    }
}

