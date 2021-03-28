using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanSystem.Infrastructure.Data
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int LoanId { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
