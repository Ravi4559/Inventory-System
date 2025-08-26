namespace InventoryPortal.Models
{
    public class AddProductDto
    {

        public required string Name { get; set; }   // Product Name


        public string? Description { get; set; }   // Product Description


        public decimal Price { get; set; }   // Product Price (money type)


        public int StockQuantity { get; set; }   // Stock count


        public string? Category { get; set; }   // Product Category
    }
}
