using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using System;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[Controller]")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;

		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Json(_productRepository.GetAll());
			}
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}
		public IActionResult Post([FromBody]Product product)
		{
			try
			{
				product.Validate();
				if (!product.IsValid)
				{
					return BadRequest(product.getValidationMessage());
				}
				if (product.Id > 0)
				{
					_productRepository.Update(product);
				}
				else
				{
					_productRepository.Add(product);
				}
				return Created("api/product", product);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody]Product product)
		{
			try
			{
				// produtoi recebido do FromBody, deve ter a propriedade Id > 0
				_productRepository.Remove(product);
				return Json(_productRepository.GetAll());
			}
			catch (Exception ex )
			{
				return BadRequest(ex.Message);
				
			}
		}
		[HttpPost("SendFile")]
		public IActionResult SendFile()
		{
			try
			{
				var result = _productRepository.FormatFile();
				if (!string.IsNullOrEmpty(result))
				{
					return Json(result);
				}
				return BadRequest("Já existe um arquivo com esse nome");
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
