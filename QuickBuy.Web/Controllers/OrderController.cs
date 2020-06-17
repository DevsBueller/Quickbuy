using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contracts;
using QuickBuy.Dominio.Entities;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private  readonly IOrderRepository _orderRepository;
        public OrderController (IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                _orderRepository.Add(order);
                return Ok(order.Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
  
}