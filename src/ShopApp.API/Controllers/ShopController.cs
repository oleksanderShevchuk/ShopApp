using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Interfaces;

namespace ShopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;
        public ShopController(IShopService service) => _service = service;

        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdays([FromQuery] DateTime date)
        {
            var list = await _service.GetBirthdaysAsync(date);
            return Ok(list);
        }

        [HttpGet("recent-customers")]
        public async Task<IActionResult> GetRecentCustomers([FromQuery] int days)
        {
            var list = await _service.GetRecentCustomersAsync(days);
            return Ok(list);
        }

        [HttpGet("customer-categories/{clientId:guid}")]
        public async Task<IActionResult> GetCustomerCategories(Guid clientId)
        {
            var list = await _service.GetCustomerCategoriesAsync(clientId);
            return Ok(list);
        }
    }
}
