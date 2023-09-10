using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;

namespace ReClaimBinApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

            [HttpPost]

            public async Task<IActionResult> CreateOrder(OrderRequestDto orderRequestDto)
            {
                var orderResult = await _orderService.CreateOrderAsync(orderRequestDto);
                return Ok(orderResult);
            }

            [HttpGet]

            public async Task<IActionResult> GetAllOrder()
            {
                var orderResult = await _orderService.GetAllOrderAsync();
                return Ok(orderResult);
            }
        }
    }
