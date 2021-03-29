using LoanSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanSystem.Core.DTOs
{
    public class UserDto: BaseEntity
    {
        public string Name { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string PhoneNumber { get; set; }
    }
}
