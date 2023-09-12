using ReClaimBinApp_Core.Model;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IReviewRepository : IRepository<Review>
    {
        void CreateReviewAsync(Review review);
        Task<IEnumerable<Review>> FindAllReview(bool trackChanges);
        Task<IEnumerable<Review>> GetReviewByOrderId(string orderId, bool trackChanges);
        void DeleteReview(Review review);
        void UpdateReview(Review review);
    }
}