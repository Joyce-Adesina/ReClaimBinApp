using ReClaimBinApp_Core.Model;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{

    public interface ISupplierRepository : IRepository<Supplier>
    {
        void CreateSupplier(Supplier supplier);
        Task<Supplier> GetSupplierById(string id, bool trackChanges);
        Task<IEnumerable<Supplier>> GetAllSuppliers(bool trackChanges);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}