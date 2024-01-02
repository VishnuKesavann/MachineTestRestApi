using MachineTestRestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTestRestApi.Repository
{
    public interface ICustomerRepository
    {

        // Listing

        Task<List<TblCustomer>> GetAllCustomer();

        // Adding
        Task<int> AddCustomer(TblCustomer cust);

        // Updating
        Task<TblCustomer> UpdateCustomer(TblCustomer cust);

        // Searching
        Task<TblCustomer> GetCustomerById(int? id);

        // Deleting
        Task<int> DeleteCustomer(int? id);




    }
}
