using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
    }
}
