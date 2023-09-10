using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction
{
    public interface IUnitOfWork
    {
        IManufacturerRepository ManufacturerRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IOrderRepository OrderRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}       
    

