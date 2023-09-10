using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Dtos.SupplierRequestDto;
using ReClaimBinApp_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface ISupplierService
    {
       
        Task<StandardResponse<SupplierResponseDto>> CreateSupplier(SupplierRequestDto requestDto);
        Task<StandardResponse<IEnumerable<SupplierResponseDto>>> GetAllSuppliers(bool trackChanges);
        Task<StandardResponse<SupplierResponseDto>> GetSupplierById(int id, bool trackChanges);
        Task<StandardResponse<int>> UpdateSupplier(int id, SupplierRequestDto requestDto);
        Task<StandardResponse<string>> DeleteSupplier(int id);
        //Task<StandardResponse<SupplierResponseDto>> GetSupplierByEmail(string email, bool trackChanges);

    }
}
