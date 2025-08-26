using InventoryPortal.Data;
using InventoryPortal.Models;
using InventoryPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPortal.Controllers
{
    // Route uses localhost here like localhost:XXXX/api/Products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;// this private key dbContext used below

        public ProductsController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("All products")]
        public IActionResult GetAllProducts()
        {
           var allProducts = dbContext.Products.ToList();//it like dbContext(its like connected to table) have all Products table variables

            return Ok(allProducts);
        }
        // Code for Search by Id
        [HttpGet]
        [Route("{id:guid} Search By Id")]
        public IActionResult GetProductById(Guid id)
        {                   // by using dbContext we can make connection to database directly
            var product = dbContext.Products.Find(id);//here product can be null

            if (product is null)
            {
                return NotFound();

            }
             return Ok(product);
        }

        // Code for Adding new Product
        [HttpPost]
        [Route("Adding new Product")]
        public IActionResult AddProduct(AddProductDto addProductDto) //for adding we product information
                                                                     // Creating a new object work as carrier know as DTo(data transfer one to another)
                                                                     //we have to convert AddProductDto to Product entity
                                                                     
        {
            var productEntity = new Product()
            {
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                StockQuantity = addProductDto.StockQuantity,
                Description = addProductDto.Description,
                Category = addProductDto.Category,
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);

        }
        // Code for Updating 
        [HttpPut]
        [Route("{id:guid} for Updating")]
        public IActionResult UpdateProduct(Guid id,UpdateProductDto updateProductDto) //UpdateProductDto here all variables there
                                                                                      //which we update
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }

            product.Price = updateProductDto.Price;
            product.Name = updateProductDto.Name;
            product.StockQuantity = updateProductDto.StockQuantity;
            product.Description = updateProductDto.Description;
            product.Category = updateProductDto.Category;

            dbContext.SaveChanges();

            return Ok(product);

        }

        // Code for Delete
        [HttpDelete]
        [Route("{id:guid} for Delete")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok();
        }

        // Search by product name 
        [HttpGet]
        [Route(" Search by-name")]
        public IActionResult GetProductByName(string name)
        {
            //  the product by Name
            var product = dbContext.Products.FirstOrDefault(p => p.Name == name);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        //Code for finding Low stock
        [HttpGet]
        [Route("checking low-stock")]
        public IActionResult GetLowStockProducts()
        {
            var lowStockProducts = dbContext.Products.Where(p => p.StockQuantity < 5)
                .ToList();

            if (lowStockProducts is null)
            {
                return NotFound();
            }

            return Ok(lowStockProducts);
        }
               

    }
}
