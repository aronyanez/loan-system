using System;
using System.Collections.Generic;
using System.Text;

namespace LoanSystem.Core.Entities
{
    public partial class Loan:BaseEntity
    {
        public Loan()
        {
            Payment = new HashSet<Payment>();
        }

        public int? TotalAmount { get; set; }
        public int? AmountPer15Days { get; set; }
        public DateTime? LoanApplication { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
