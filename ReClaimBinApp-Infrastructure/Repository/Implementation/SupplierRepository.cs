using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        /*  private readonly DbSet<Supplier> suppliers;*/
        public SupplierRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            /*suppliers = appDbContext.Set<Supplier>();*/
        }
        public void CreateSupplier(Supplier supplier)
        {
            Create(supplier);
        }
        public async Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        //public async Task<Supplier> GetSupplierByEmail(string email, bool trackChanges)
        //{
        //    return await FindByCondition(s => s. == email, false).FirstOrDefaultAsync();
        //}
        public async Task<Supplier> GetSupplierById(string id, bool trackChanges)
        {
            return await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
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
