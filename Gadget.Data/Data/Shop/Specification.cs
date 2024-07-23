using System.ComponentModel.DataAnnotations;

namespace Gadget.Data.Data.Shop
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must not be empty")]
        [StringLength(100)]
        public string Name { get; set; }
        public List<ProductSpecification> ProductSpecification { get; } = new List<ProductSpecification>();
    }
}
