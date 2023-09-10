using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        void CreateManufacturer(Manufacturer manufacturer);
        Task<IEnumerable<Manufacturer>> GetAllManufacturers(bool trackChanges);
        Task<Manufacturer> GetManufacturerById(string id, bool trackChanges);
        //Task<Manufacturer> GetManufacturerByEmail(string email, bool trackChanges);
        //Task<Manufacturer> GetManufacturerByEmail(string email, bool trackChanges);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);

    }



}
