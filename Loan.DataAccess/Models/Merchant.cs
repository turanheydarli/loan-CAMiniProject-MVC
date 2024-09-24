using System;
using System.Collections.Generic;

namespace Loan.DataAccess.Models
{
    public class Merchant : BaseEntity
        {
            public string Name { get; set; }
            public string UserId { get; set; }

            public AppUser User { get; set; }
            public ICollection<Branch> Branches { get; set; }  
        }
}