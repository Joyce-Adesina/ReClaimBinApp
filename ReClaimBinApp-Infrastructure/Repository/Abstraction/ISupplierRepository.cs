using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Dtos.SupplierRequestDto;
using ReClaimBinApp_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{

    public interface ISupplierRepository : IRepository<Supplier>
    {
        void CreateSupplier(Supplier supplier);
        Task<Supplier> GetSupplierById(string id, bool trackChanges);
        Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges);
        //Task<Supplier> GetSupplierByEmail(string email, bool trackChanges);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);


    }
}

