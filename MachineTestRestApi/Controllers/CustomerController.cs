using MachineTestRestApi.Models;
using MachineTestRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTestRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        //data field 

        private readonly ICustomerRepository _customerRepository;

        // constructor injection

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }



        #region Listing
        [HttpGet]
        [Route("List")]   // It is used in the case of not specifying the action

        public async Task<ActionResult<IEnumerable<TblCustomer>>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }
        #endregion


        #region Adding
        [HttpPost]
        [Route("Insert")]

        public async Task<IActionResult> AddCustomer([FromBody] TblCustomer cust)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cid = await _customerRepository.AddCustomer(cust);
                    if (cid > 0)
                    {
                        return Ok(cid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Updating

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] TblCustomer cust)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateCustomer(cust);
                    return Ok(cust);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion


        #region Searching

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<TblCustomer>> GetCustomerById(int? id)
        {
            try
            {
                var cus = await _customerRepository.GetCustomerById(id);
                if (cus == null)
                {
                    return NotFound();

                }
                return Ok(cus);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion


        #region Deleting
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            try
            {
                var cid = await _customerRepository.DeleteCustomer(id);
                if (cid > 0)
                {
                    return Ok(cid);
                }
                else
                {
                    return NotFound();

                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

    }
}
