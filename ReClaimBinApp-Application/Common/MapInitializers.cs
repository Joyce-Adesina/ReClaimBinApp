using AutoMapper;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Dtos.SupplierRequestDto;
using ReClaimBinApp_Core.Model;

namespace ReClaimBinApp_Application.Common
{
    public class MapInitializers:Profile
    {
        public MapInitializers()
        {
            CreateMap<ManufacturerRequestDto, Manufacturer>();
            CreateMap<Manufacturer, ManufacturerResponseDto>();
            CreateMap<SupplierRequestDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
            CreateMap<OrderRequestDto, Order>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<ReviewRequestDto, Review>();
            CreateMap<Review, ReviewResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserResponseDto>();


        }
    }
}
