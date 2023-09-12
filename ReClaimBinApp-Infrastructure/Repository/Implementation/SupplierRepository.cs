using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using ReClaimBinApp_Shared.RequestParameter.Common;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        
        }
        public void CreateSupplier(Supplier supplier)
        {
            Create(supplier);
        }
        public async Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<PagedList<Supplier>> GetAllSuppliers(SupplierRequestInputParameter parameter, bool trackChanges)
        {
            var suppliers = FindAll(trackChanges); // Assuming FindAll returns an IQueryable

            var pagedSuppliers = await suppliers
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .ToListAsync();

            var totalCount = await suppliers.CountAsync();

            return new PagedList<Supplier>(pagedSuppliers, totalCount, parameter.PageNumber, parameter.PageSize);
        }
        public async Task<Supplier> GetSupplierById(string id, bool trackChanges)
        {
            var result = await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
            return result;
        }
        public void UpdateSupplier(Supplier supplier)
        {
            Update(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            Delete(supplier);
        }

    }
}
