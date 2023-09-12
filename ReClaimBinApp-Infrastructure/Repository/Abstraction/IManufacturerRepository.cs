using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Shared.RequestParameter.Common;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        void CreateManufacturer(Manufacturer manufacturer);
        Task<PagedList<Manufacturer>> GetAllManufacturers(ManufacturerRequestInputParameter parameter, bool trackChanges);
        Task<Manufacturer> GetManufacturerById(string id, bool trackChanges);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
    }
}