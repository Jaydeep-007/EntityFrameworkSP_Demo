using EntityFrameworkSP_Demo.Entities;
using EntityFrameworkSP_Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EntityFrameworkSP_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getproductlist")]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                return await productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getproductbyid")]
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
            try
            {
                var response = await productService.GetProductByIdAsync(Id);

                if(response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await productService.AddProductAsync(product);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateproduct")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result =  await productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deleteproduct")]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
