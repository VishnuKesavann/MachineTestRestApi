using System;

namespace MachineTestRestApi.View_Model
{
    public class CustomerOrd
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }


    }
}
