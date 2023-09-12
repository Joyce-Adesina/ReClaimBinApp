using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Shared.RequestParameter.Common;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface IManufacturerService
    {
        Task<StandardResponse<ManufacturerResponseDto>> CreateManufacturer(ManufacturerRequestDto requestDto);
        Task<StandardResponse<(IEnumerable<ManufacturerResponseDto>, MetaData)>> GetAllManufacturers(ManufacturerRequestInputParameter parameter, bool trackChanges);
        Task<StandardResponse<ManufacturerResponseDto>> GetManufacturerById(string id, bool trackChanges);
        Task<StandardResponse<int>> UpdateManufacturer(string id, ManufacturerRequestDto requestDto);
        Task<StandardResponse<string>> DeleteManufacturer(string id);
    }
}