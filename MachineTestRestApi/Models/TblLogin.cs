using System;
using System.Collections.Generic;

namespace MachineTestRestApi.Models
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblCustomer = new HashSet<TblCustomer>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblCustomer> TblCustomer { get; set; }
    }
}
