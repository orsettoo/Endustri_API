using Endustri_API.Entity.Base;

namespace Endustri_API.Entity
{
    public class Category :BaseEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
