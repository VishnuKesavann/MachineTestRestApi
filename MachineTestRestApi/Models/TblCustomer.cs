using System;
using System.Collections.Generic;

namespace MachineTestRestApi.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual TblLogin L { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
