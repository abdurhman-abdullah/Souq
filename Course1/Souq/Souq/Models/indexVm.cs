namespace Souq.Models
{
    public class indexVm
    {
        public indexVm()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
            LatestProducts = new List<Product>();
            Reviews = new List<Review>();
            productImages = new List<ProductImage>();
        }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> LatestProducts { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductImage> productImages { get; set; }
    }
}
