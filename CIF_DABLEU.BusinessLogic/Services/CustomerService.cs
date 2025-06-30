using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.Customer.GetAllAsync();
        }
    }
}
