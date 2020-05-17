using QuickBuy.Dominio.Entities;
using QuickBuy.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Repositorio.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace QuickBuy.Repositorio.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		private IHttpContextAccessor _httpContextAccessor;
		private IHostingEnvironment _hostingEnvironment;
		public ProductRepository(QuickBuyContext quickBuyContext, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment) : base(quickBuyContext)
		{
			_httpContextAccessor = httpContextAccessor;
			_hostingEnvironment = hostingEnvironment;
		}
		public string FormatFile()
		{
			string path;
			try
			{
				var file = _httpContextAccessor.HttpContext.Request.Form.Files["sentFile"];
				var fileName = file.FileName;
				var newCompleteName = new string(Path.GetFileNameWithoutExtension(fileName)
					.Take(10).ToArray())
					.Replace(" ", "-") + "."+ fileName.Split('.').Last();
				path = _hostingEnvironment.WebRootPath + "\\files\\" + newCompleteName;
				if (!File.Exists(path))
				{
					using (var streamFile = new FileStream(path, FileMode.Create))
					{
						file.CopyTo(streamFile);
					}
					return newCompleteName;
				}
				else { return ""; }
			
			}
			
			
			catch (Exception ex)
			{
	
				throw ex;
			}
		}
	}
}
