using System;
using System.Collections.Generic;

namespace Souq.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Catid { get; set; }
        public string? Photo { get; set; }
        public string? SupplierName { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? ReviewUrl { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
