using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;

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
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        //public async Task <IEnumerable<Manufacturer>> GetAllSuppliersBySaleRequest(DateTime)
        //{
        //    return await FindByCondition(m => m.)
        //}
        

        //public async Task<Manufacturer> GetManufacturerByEmail(string email, bool trackChanges)
        //{
        //    return await FindByCondition(m => m.Email == email, trackChanges).FirstOrDefaultAsync();
        //}

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
