using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateOrderAsync(Order order)
        {
            Create(order);
        }
        public async Task<IEnumerable<Order>> GetAllOrders(bool trackChanges)
        {
            return await FindAll(false).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderBySupplierId(int id, bool trackChanges)
        {
            return await FindByCondition(O => O.SupplierId ==  id, trackChanges).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderByManufacturerName(string name, bool trackChanges)
        {
            return await FindByCondition(O => O.ManufacturerToSell == name, trackChanges).ToListAsync();
        }
        public async Task<Order> GetOrderById(int id, bool trackChanges)
        {
            return await FindByCondition(O => O.Id == id, trackChanges).FirstOrDefaultAsync();
        }
        public async void UpdateOrder(Order order)
        {
           UpdateOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            DeleteOrder(order);
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            RemoveRange(entities);
        }
    }
}

