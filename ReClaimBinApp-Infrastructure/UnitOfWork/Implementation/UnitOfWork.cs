using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using ReClaimBinApp_Infrastructure.Repository.Implementation;
using ReClaimBinApp_Infrastructure.Repository.Implementation.Manu;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;

namespace ReClaimBinApp_Infrastructure.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IManufacturerRepository _manufacturerRepository;
        private ISupplierRepository _supplierRepository;
        private IReviewRepository _reviewRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IManufacturerRepository ManufacturerRepository => _manufacturerRepository ??= new ManufacturerRepository(_context);

        public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(_context);

        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_context);

        public IOrderRepository OrderRepository =>_orderRepository??= new OrderRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
