using MachineTestRestApi.Models;
using MachineTestRestApi.View_Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace MachineTestRestApi.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {


        //Data fields
        private readonly Sale_dbContext _dbContext;

        public PurchaseRepository(Sale_dbContext dbContext)
        {
            _dbContext = dbContext;
        }




        #region GET ALL Order
        public async Task<List<PurchaseOrder>> GetAllOrder()
        {

            if (_dbContext != null)
            {
                return await _dbContext.PurchaseOrder.ToListAsync();
            }
            return null;

        }
        #endregion


        #region Add a Order

        public async Task<int> AddOrder(PurchaseOrder ord)
        {
            if (_dbContext != null)
            {
                await _dbContext.PurchaseOrder.AddAsync(ord);
                // for commiting the transaction
                await _dbContext.SaveChangesAsync();

                return ord.OId;
            }

            return 0;
        }

        #endregion


        #region updating with obj

        public async Task<PurchaseOrder> UpdateOrder(PurchaseOrder ord)
        {
            if (_dbContext != null)
            {
                _dbContext.Entry(ord).State = EntityState.Modified; // to modifying the values
                _dbContext.PurchaseOrder.Update(ord);
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }

        #endregion


        #region Get Order By Id

        public async Task<PurchaseOrder> GetOrderById(int? id)
        {
            if (_dbContext != null)
            {
                var ord = await _dbContext.PurchaseOrder.FindAsync(id);
                return ord;
            }
            return null;
        }

        #endregion


        #region Delete Order

        public async Task<int> DeleteOrder(int? id)
        {
            if (_dbContext != null)
            {
                var ord1 = await _dbContext.PurchaseOrder.FirstOrDefaultAsync(ord => ord.OId == id);

                if (ord1 != null)
                {
                    // Delete 
                    _dbContext.PurchaseOrder.Remove(ord1);

                    await _dbContext.SaveChangesAsync();
                    return ord1.OId;
                }
            }
            return 0;
        }


        #endregion



        #region  View Model

        public async Task<List<CustomerOrd>> GetCustOrdDetails()
        {
            if (_dbContext != null)
            {
                // LINQ
                var query = from c in _dbContext.TblCustomer
                            join p in _dbContext.PurchaseOrder on c.CId equals p.CId
                            select new CustomerOrd
                            {
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Address = c.Address,
                                PhoneNumber = c.PhoneNumber,
                                PurchaseOrderNumber = p.PurchaseOrderNumber,
                                ItemName = p.ItemName,
                                Quantity = p.Quantity,
                                OrderDate = p.OrderDate,
                                DeliveryDate = p.DeliveryDate



                            };

                return await query.ToListAsync();
            }

            return null;
        }

        #endregion

        



    }
}
