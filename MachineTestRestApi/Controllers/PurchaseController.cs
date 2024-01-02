using MachineTestRestApi.Models;
using MachineTestRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MachineTestRestApi.View_Model;

namespace MachineTestRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        //data field 

        private readonly IPurchaseRepository _purchaseRepository;

        // constructor injection

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }



        #region Listing
        [HttpGet]
        [Route("List")]   // It is used in the case of not specifying the action

        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetAllCustomer()
        {
            return await _purchaseRepository.GetAllOrder();
        }
        #endregion


        #region Adding
        [HttpPost]
        [Route("Insert")]

        public async Task<IActionResult> AddCustomer([FromBody] PurchaseOrder ord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var oid = await _purchaseRepository.AddOrder(ord);
                    if (oid > 0)
                    {
                        return Ok(oid);
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
        public async Task<IActionResult> UpdateOrder([FromBody] PurchaseOrder ord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _purchaseRepository.UpdateOrder(ord);
                    return Ok(ord);
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

        public async Task<ActionResult<PurchaseOrder>> GetOrderById(int? id)
        {
            try
            {
                var ord = await _purchaseRepository.GetOrderById(id);
                if (ord == null)
                {
                    return NotFound();

                }
                return Ok(ord);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion


        #region Deleting
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            try
            {
                var oid = await _purchaseRepository.DeleteOrder(id);
                if (oid > 0)
                {
                    return Ok(oid);
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


        #region View Model
        [HttpGet]
        [Route("view")]
        public async Task<ActionResult<IEnumerable<CustomerOrd>>> GetCustOrdVM()
        {
            return await _purchaseRepository.GetCustOrdDetails();
        }

        #endregion

    }
}
