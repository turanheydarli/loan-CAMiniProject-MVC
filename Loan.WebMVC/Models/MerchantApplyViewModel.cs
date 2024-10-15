using Loan.Application.DTOs;
using Loan.WebMVC.Areas.Admin.Controllers;

namespace Loan.WebMVC.Models;

public class MerchantApplyViewModel
{
    public UserDto User { get; set; }
    public MerchantDto Merchant { get; set; }
}