using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using ReClaimBinApp_Shared.RequestParameter.Common;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation.Manu
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public void CreateManufacturer(Manufacturer manufacturer)
        {
            Create(manufacturer);
        }
        public async Task<PagedList<Manufacturer>> GetAllManufacturers(ManufacturerRequestInputParameter parameter, bool trackChanges)
        {
            var manufacturers = FindAll(trackChanges); // Assuming FindAll returns an IQueryable

            var pagedManufacturers = await manufacturers
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .ToListAsync();

            var totalCount = await manufacturers.CountAsync();

            return new PagedList<Manufacturer>(pagedManufacturers, totalCount, parameter.PageNumber, parameter.PageSize);
        }



        public async Task<Manufacturer> GetManufacturerById(string id, bool trackChanges)
        {
            return await FindByCondition(m => m.Id == id, trackChanges).FirstOrDefaultAsync();
        }
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            Update(manufacturer);
        }
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            Delete(manufacturer);
        }
    }
}
