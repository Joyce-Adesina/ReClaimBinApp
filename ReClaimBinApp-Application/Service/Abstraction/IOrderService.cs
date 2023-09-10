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
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetOrderById(int id);
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetOrderBySupplierId(int id, bool trackChanges);
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> UpdateOrder(int id, OrderRequestDto orderRequest);
    }
}