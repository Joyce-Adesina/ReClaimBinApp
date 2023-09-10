using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Repository.Implementation;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Implementation
{
    public class OrderService : IOrderService
    {
        public readonly ILogger<OrderService> _logger;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public OrderService(ILogger<OrderService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<StandardResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto orderRequestDto)
        {
            if (orderRequestDto == null)
            {
                _logger.LogError("Field cannot be empty");
                return StandardResponse<OrderResponseDto>.Failed("Field cannot be empty");
            }

            _logger.LogInformation("Attempting to create order");
            var order = _mapper.Map<Order>(orderRequestDto);
            _unitOfWork.OrderRepository.Create(order);
            await _unitOfWork.SaveAsync();
            var returnOrder = _mapper.Map<OrderResponseDto>(order);
            return StandardResponse<OrderResponseDto>.Success("Order creation successful", returnOrder);
        }

        public async Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetAllOrderAsync()
        {
            _logger.LogInformation("Attempting to get all orders");
            var orders = await _unitOfWork.OrderRepository.GetAllOrders(false);
            var orderResponseDto = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);

            return StandardResponse<IEnumerable<OrderResponseDto>>.Success("successfully retrieved all Orders", orderResponseDto, 200);


        }
        public async Task<StandardResponse<OrderResponseDto>> GetOrderById(string id, bool trackChanges)
        {
            _logger.LogInformation($" Attempting to get id by id {id}");
            var orders = await _unitOfWork.OrderRepository.GetOrderById(id,trackChanges);
            var orderResponseDto = _mapper.Map<OrderResponseDto>(orders);

            return StandardResponse<OrderResponseDto>.Success("successfully retrieved Order",orderResponseDto, 200);
        }
        public async Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetOrderBySupplierId(string id ,bool trackChanges)
        {
            _logger.LogInformation($"Attempting to get id by id {id} is {trackChanges}");
            var orders = await _unitOfWork.OrderRepository.GetOrderBySupplierId(id, trackChanges);
            var orderResponseDto = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);

            return StandardResponse<IEnumerable<OrderResponseDto>>.Success("successfully retrieved an Order", orderResponseDto, 200);
        }
        /// <summary>
        /// This method updates a single order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        public async Task<StandardResponse<OrderResponseDto>> UpdateOrder(string id, OrderRequestDto orderRequest)
        {

            var orders = await _unitOfWork.OrderRepository.GetOrderById(id, true);
            if (orders == null)
            {
                _logger.LogError("Order not found in the database. Update Aborting");
                return StandardResponse<OrderResponseDto>.Failed("Order not found in database", 99);
            }
            var order = _mapper.Map<Order>(orderRequest);
            _unitOfWork.OrderRepository.UpdateOrder(order);
            await _unitOfWork.SaveAsync();
            var orderResponse = _mapper.Map<OrderResponseDto>(order);
            return StandardResponse<OrderResponseDto>.Success("", orderResponse, 0);
        }


        
        /*        public async Task<StandardResponse<OrderResponseDto>> GetBSupplierUserNameasync(OrderRequestDto orderRequestDto)
                {
                    if (orderRequestDto == null)
                    {
                        _logger.LogError("Field cannot be empty");
                        return StandardResponse<OrderResponseDto>.Failed("Field cannot be empty");
                    }
                    _logger.LogInformation("attempting to get all order");
                    var order = _mapper.Map<Order>(orderRequestDto);
                    _unitOfWork.OrderRepository.FindAll(order);
                    _unitOfWork.SaveAsync();
                    var returnOrder = _mapper.Map<OrderResponseDto>(order);
                    return StandardResponse<OrderResponseDto>.Success("successful", returnOrder);
                }*/





        /*        public async Task<StandardResponse<OrderResponseDto>> GetOrderById(OrderRequestDto orderRequestDto)
                { 
                    if (OrderRequestDto == null)
                    {
                        _logger.LogError("Field cannot be empty");
                        return StandardResponse<OrderResponseDto>.Failed("Field cannot be empty");
                    }
                    _logger.
                }*/
    }
}
