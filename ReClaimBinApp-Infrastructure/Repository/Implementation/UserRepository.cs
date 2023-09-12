using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.Repository.Abstraction;
using ReClaimBinApp_Shared.RequestParameter.Common;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Infrastructure.Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public void CreateUser(User user)
        {
            Create(user);
        }
        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter, bool trackChanges)
        {
            var users = FindAll(trackChanges); // Assuming FindAll returns an IQueryable

            var pagedUsers = await users
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .ToListAsync();

            var totalCount = await users.CountAsync();

            return new PagedList<User>(pagedUsers, totalCount, parameter.PageNumber, parameter.PageSize);
        }
        public async Task<User> GetUserById(string id, bool trackChanges)
        {
            var result = await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
            return result;
        }
        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}
