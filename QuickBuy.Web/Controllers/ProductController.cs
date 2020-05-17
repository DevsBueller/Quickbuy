using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using QuickBuy.Repositorio;
using QuickBuy.Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[Controller]")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private IHttpContextAccessor _httpContextAccessor;
		private IHostingEnvironment _hostingEnvironment;
		public ProductController(IProductRepository productRepository,IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
		{
			_productRepository = productRepository;
			_httpContextAccessor = httpContextAccessor;
			_hostingEnvironment = hostingEnvironment;
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
