using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanSystem.Infrastructure.Data
{
    public partial class User
    {
        public User()
        {
            Loan = new HashSet<Loan>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
