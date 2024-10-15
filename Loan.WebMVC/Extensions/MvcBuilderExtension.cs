using NToastNotify;

namespace Loan.WebMVC.Extensions;

public static class MvcBuilderExtension
{
    public static IMvcBuilder AddMvcSettings(this IMvcBuilder builder)
    {
        builder.AddNToastNotifyToastr(new ToastrOptions
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ShowDuration = 500
            }
        );
        
        return builder;
    }
}