using Loan.Application.DTOs;
using Loan.WebMVC.Areas.Admin.Controllers;

namespace Loan.WebMVC.Models;

public class MerchantApplyViewModel
{
    public MerchantDto Merchant { get; set; }

    public IFormFile BusinessLicenceFile { get; set; }
}