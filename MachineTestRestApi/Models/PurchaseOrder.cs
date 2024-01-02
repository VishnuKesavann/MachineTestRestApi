using System;
using System.Collections.Generic;

namespace MachineTestRestApi.Models
{
    public partial class PurchaseOrder
    {
        public int OId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }
        public int? CId { get; set; }
        public int? VId { get; set; }

        public virtual TblCustomer C { get; set; }
        public virtual TblVendor V { get; set; }
    }
}
