using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface IOrderService
    {
        Task<StandardResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto orderRequestDto);
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetAllOrderAsync();
        Task<StandardResponse<OrderResponseDto>> GetOrderById(string id, bool trackChanges);
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetOrderBySupplierId(string id, bool trackChanges);
        Task<StandardResponse<OrderResponseDto>> UpdateOrder(string id, OrderRequestDto orderRequest);
    }
}