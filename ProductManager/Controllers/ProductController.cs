using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Model.Entity;
using ProductManager.Model.Objects;
using ProductManager.Services;
using ProductManager.Utilies;
using System.Net;

namespace ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //Implementacion del servicio de productos
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            Tools tools = new Tools();

            if (product.Price != null)
            {
                if (!tools.ValidatePrice(product.Price, true)) { return BadRequest("El precio del producto debe ser un numero positivo"); }
            }
            if (product.PriceWithDiscount != null)
            {
                if (!tools.ValidatePrice(product.PriceWithDiscount, true)) { return BadRequest("El precio de descuento del producto debe ser un numero positivo"); }
            }

            return Ok(_productService.AddProduct(product));
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            Tools tools = new Tools();

            if (product.Price != null) 
            {
                if (!tools.ValidatePrice(product.Price, false)) { return BadRequest("El precio del producto debe ser mayor a 0"); }
            }
            if (product.PriceWithDiscount != null)
            {
                if (!tools.ValidatePrice(product.PriceWithDiscount, false)) { return BadRequest("El precio de descuento del producto debe ser mayor a 0"); }
            }

            return Ok(_productService.UpdateProduct(product));
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }

        [HttpPut]
        [Route("/UpdatePrice")]
        public IActionResult UpdatePrices([FromBody] UpdatePriceRequest newPrice)
        {
            var existingProduct = _productService.GetProductById(newPrice.IdProduct);

            string msj = "";

            if (existingProduct != null)
            {
                Tools tools = new Tools();
                // Validar el nuevo precio si es mayor a 0
                if (tools.ValidatePrice(newPrice.Price, false))
                {
                    existingProduct.Price = newPrice.Price;
                    return Ok(_productService.UpdateProduct(existingProduct));
                }
                else
                {
                    msj = "El precio debe ser mayor a 0";
                }
            }
            else
            {
                msj = "El producto No existe";
            }
            return BadRequest(msj);
        }

        [HttpPut]
        [Route("/UpdatePriceWithDiscount")]
        public IActionResult UpdatePriceWithDiscount([FromBody] UpdatePriceRequest newPrice)
        {
            var existingProduct = _productService.GetProductById(newPrice.IdProduct);

            string msj = "";

            if (existingProduct != null)
            {
                Tools tools = new Tools();

                // Validar el nuevo precio si es mayor a 0
                if (tools.ValidatePrice(newPrice.Price, false))
                {
                    existingProduct.PriceWithDiscount = newPrice.Price;
                    return Ok(_productService.UpdateProduct(existingProduct));
                }
                else
                {
                    msj = "El precio de descuento debe ser mayor a 0";
                }
            }
            else
            {
                msj = "El producto No existe";
            }
            return BadRequest(msj);
        }
    }
}
