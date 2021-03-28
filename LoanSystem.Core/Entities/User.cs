using System;
using System.Collections.Generic;
using System.Text;

namespace LoanSystem.Core.Entities
{
    public partial class User:BaseEntity
    {


        public User()
        {
            Loan = new HashSet<Loan>();
        }

        public string Name { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
