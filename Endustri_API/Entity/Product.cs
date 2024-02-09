using Endustri_API.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Endustri_API.Entity
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        
        public string ProductDescription { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]

        public virtual Category Category { get; set; }

        
    }
}
