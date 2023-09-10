using ReClaimBinApp_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.Repository.Abstraction
{
    public interface IReviewRepository : IRepository<Review>
    {
        void CreateReviewAsync(Review review);
        Task<IEnumerable<Review>> FindAllReview(bool trackChanges);
        Task<IEnumerable<Review>> GetReviewByOrderId(string orderId, bool trackChanges);
        void DeleteReview(Review review);
        void UpdateReview(Review review);
        //Search term will use searching        
    }
}

