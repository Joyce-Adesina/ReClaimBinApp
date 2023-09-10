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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void CreateReviewAsync(Review review)
        {
            Create(review);
        }

        public void DeleteReview(Review review)
        {
            Delete(review);
        }

        public async Task<IEnumerable<Review>> FindAllReview(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        //public async Task<Review> GetReviewById(string id, bool trackChanges)
        //{
        //    return await FindByCondition(r => r.Id == id, trackChanges).FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<Review>> GetReviewByOrderId(int orderId, bool trackChanges)
        {
            return await FindByCondition(r => r.OrderId == orderId, trackChanges).ToListAsync();
        }

        public void UpdateReview(Review review)
        {
            Update(review);
        }
    }
}

