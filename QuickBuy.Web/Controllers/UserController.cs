using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{
	[Route("api/[Controller]")]
	public class UserController: Controller
	{
		private readonly IUserRepository _userRepository;
		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok();
			}
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}
		[HttpPost]
		public IActionResult Post([FromBody] User user)
		{
			try
			{
				var userRegisted = _userRepository.Get(user.Email);
				if(userRegisted != null)
				{
					return BadRequest("O usuário já existe na base de dados");
				}
		
				_userRepository.Add(user);
				return Ok();
			}
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}

		[HttpPost("VerifyUser")]
		public IActionResult VerifyUser([FromBody] User user)
		{
			try
			{
				var userReturn = _userRepository.Get(user.Email, user.Password);
				if(userReturn != null) {
					return Ok(userReturn);
				}

				return BadRequest("Usuário ou senha inválidos");
			}
	
			catch (Exception ex)
			{

				return BadRequest(ex.ToString());
			}
		}
	}
}
