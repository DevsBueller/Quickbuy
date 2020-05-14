using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using QuickBuy.Repositorio;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
				return Ok(_productRepository.GetAll());
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
				_productRepository.Add(product);
				return Created("api/product", product);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}
	}
}
