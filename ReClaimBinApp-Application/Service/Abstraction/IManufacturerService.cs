using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Infrastructure.Repository.Implementation.Manu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface IManufacturerService
    {
        Task<StandardResponse<ManufacturerResponseDto>> CreateManufacturer(ManufacturerRequestDto requestDto);
        Task<StandardResponse<IEnumerable<ManufacturerResponseDto>>> GetAllManufacturers(bool trackChanges);
        Task<StandardResponse<ManufacturerResponseDto>> GetManufacturerById(int id, bool trackChanges);
        //Task<StandardResponse<ManufacturerResponseDto>> GetManufacturerByEmail(string email, bool trackChanges);
        Task<StandardResponse<int>> UpdateManufacturer(int id, ManufacturerRequestDto requestDto);
        Task<StandardResponse<string>> DeleteManufacturer(int id);

    }
}
