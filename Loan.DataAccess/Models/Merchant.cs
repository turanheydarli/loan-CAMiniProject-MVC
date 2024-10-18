using System;
using System.Collections.Generic;

namespace Loan.DataAccess.Models
{
    public class Merchant : BaseEntity
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public MerchantStatus Status { get; set; }
        public int CurrentStep { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ActivationToken { get; set; }
        public DateTime ActivationTokenExpiry { get; set; }
        public Guid BusinessLicenseId { get; set; }
        public string RegistrationNotes { get; set; }

        public ICollection<Branch> Branches { get; set; }
    }

    public enum MerchantStatus
    {
        AwaitingApproval = 0,
        Approved = 1,
        Rejected = 2,
        Active = 3
    }
}