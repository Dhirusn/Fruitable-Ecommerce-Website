using System.ComponentModel.DataAnnotations;

namespace Fruitable.Models
{
    public class Categories
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
