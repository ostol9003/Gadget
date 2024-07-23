using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gadget.Data.Data.Shop
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Description must not be empty")]
        [Column(TypeName = "text")]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "Price must not be empty")]
        [Range(0.01, 100000, ErrorMessage = "Price range 0.01 - 100,000.00")]
        public decimal Price { get; set; } = default!;

        [Required(ErrorMessage = "Photo Url must not be empty")]
        public string PhotoUrl { get; set; }

        public bool Availability { get; set; } = false;

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }

        [ForeignKey("Producerss")]
        public int ProducerId { get; set; }
        public Producers? Producer { get; set; }
        public List<ProductSpecification>? ProductSpecification { get; } = new List<ProductSpecification>();
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public bool IsPromoted { get; set; } = false;
    }
}
