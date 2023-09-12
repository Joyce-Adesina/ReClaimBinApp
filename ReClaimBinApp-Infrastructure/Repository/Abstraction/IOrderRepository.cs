using ReClaimBinApp_Core.Model;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderById(string id, bool trackChanges);
        Task<IEnumerable<Order>> GetOrderBySupplierId(string id, bool trackChanges);
        Task<IEnumerable<Order>> GetAllOrders(bool trackChanges);
        void CreateOrderAsync(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void RemoveRange(IEnumerable<Order> entities);
    }
}