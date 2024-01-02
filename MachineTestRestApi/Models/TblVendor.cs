using System;
using System.Collections.Generic;

namespace MachineTestRestApi.Models
{
    public partial class TblVendor
    {
        public TblVendor()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int VId { get; set; }
        public string VendorName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
