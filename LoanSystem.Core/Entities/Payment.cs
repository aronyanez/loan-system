using System;
using System.Collections.Generic;
using System.Text;

namespace LoanSystem.Core.Entities
{
    
        public partial class Payment: BaseEntity
        {
            public DateTime? PaymentDate { get; set; }
            public int? Amount { get; set; }
            public string PaymentMethod { get; set; }
            public int LoanId { get; set; }

            public virtual Loan Loan { get; set; }
        }
    
}
