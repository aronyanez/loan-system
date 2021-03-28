using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanSystem.Infrastructure.Data
{
    public partial class Loan
    {
        public Loan()
        {
            Payment = new HashSet<Payment>();
        }

        public int LoanId { get; set; }
        public int? TotalAmount { get; set; }
        public int? AmountPer15Days { get; set; }
        public DateTime? LoanApplication { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
