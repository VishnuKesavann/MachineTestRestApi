using MachineTestRestApi.Models;
using MachineTestRestApi.View_Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTestRestApi.Repository
{
    public interface IPurchaseRepository
    {

        Task<List<PurchaseOrder>> GetAllOrder();
        Task<int> AddOrder(PurchaseOrder ord);
        Task<PurchaseOrder> UpdateOrder(PurchaseOrder ord);
        Task<PurchaseOrder> GetOrderById(int? id);
        Task<int> DeleteOrder(int? id);
        Task<List<CustomerOrd>> GetCustOrdDetails();

     

    }
}
