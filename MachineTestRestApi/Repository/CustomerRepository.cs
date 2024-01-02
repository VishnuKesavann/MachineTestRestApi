using MachineTestRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTestRestApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        //Data fields
        private readonly Sale_dbContext _dbContext;

        public CustomerRepository(Sale_dbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Listing all
        #region GET ALL Customer
        public async Task<List<TblCustomer>> GetAllCustomer()
        {

            if (_dbContext != null)
            {
                return await _dbContext.TblCustomer.ToListAsync();
            }
            return null;

        }
        #endregion

        // Adding an Customer

        #region Add a Customer

        public async Task<int> AddCustomer(TblCustomer cust)
        {
            if (_dbContext != null)
            {
                await _dbContext.TblCustomer.AddAsync(cust);
                // for commiting the transaction
                await _dbContext.SaveChangesAsync();

                return cust.CId;
            }

            return 0;
        }

        #endregion


        // Update
        #region updating with obj

        public async Task<TblCustomer> UpdateCustomer(TblCustomer cust)
        {
            if (_dbContext != null)
            {
                _dbContext.Entry(cust).State = EntityState.Modified; // to modifying the values
                _dbContext.TblCustomer.Update(cust);
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }

        #endregion

        // get customer by id

        #region Get Customer By Id

        public async Task<TblCustomer> GetCustomerById(int? id)
        {
            if (_dbContext != null)
            {
                var cust = await _dbContext.TblCustomer.FindAsync(id);
                return cust;
            }
            return null;
        }

        #endregion

        // Deleting 

        #region Delete Customer

        public async Task<int> DeleteCustomer(int? id)
        {
            if (_dbContext != null)
            {
                var cus1 = await _dbContext.TblCustomer.FirstOrDefaultAsync(cus => cus.CId == id);

                if (cus1 != null)
                {
                    // Delete 
                    _dbContext.TblCustomer.Remove(cus1);

                    await _dbContext.SaveChangesAsync();
                    return cus1.CId;
                }
            }
            return 0;
        }


        #endregion







    }
}
