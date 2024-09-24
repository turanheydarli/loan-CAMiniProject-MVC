using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Loan.Shared.Exceptions; // Ensure correct namespace
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Loan.WebMVC.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is IdentityException identityException)
            {
                _logger.LogWarning("IdentityException occurred: {Errors}",
                    string.Join(", ", identityException.IdentityErrors.Select(e => e.Description)));

                foreach (var error in identityException.IdentityErrors)
                {
                    context.ModelState.AddModelError(string.Empty, error.Description);
                }

                context.Result = CreateViewResult(context);
                context.ExceptionHandled = true;
            }
            // Handle UserNotFoundException
            else if (context.Exception is UserNotFoundException userNotFoundException)
            {
                _logger.LogWarning("UserNotFoundException: {Message}", userNotFoundException.Message);

                context.ModelState.AddModelError(string.Empty, userNotFoundException.Message);

                context.Result = CreateViewResult(context);
                context.ExceptionHandled = true;
            }
            // Handle InvalidCredentialsException
            else if (context.Exception is InvalidCredentialsException invalidCredentialsException)
            {
                _logger.LogWarning("InvalidCredentialsException: {Message}", invalidCredentialsException.Message);

                context.ModelState.AddModelError(string.Empty, invalidCredentialsException.Message);

                context.Result = CreateViewResult(context);
                context.ExceptionHandled = true;
            }
            // Optionally, handle other custom exceptions here

            // Optionally, handle generic exceptions
            // else
            // {
            //     _logger.LogError(context.Exception, "An unhandled exception occurred.");
            //     context.Result = new ViewResult
            //     {
            //         ViewName = "Error",
            //         ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
            //         {
            //             { "ErrorMessage", "An unexpected error occurred. Please try again later." }
            //         }
            //     };
            //     context.ExceptionHandled = true;
            // }
        }

        private ViewResult CreateViewResult(ExceptionContext context)
        {
            // Determine the current action name to return the same view
            var actionName = context.RouteData.Values["action"].ToString();

            // Initialize ViewData
            ViewDataDictionary viewData;

            {
                // If casting fails, create a new ViewDataDictionary with ModelState
                viewData = new ViewDataDictionary(
                    metadataProvider: new EmptyModelMetadataProvider(),
                    modelState: context.ModelState
                );
            }

            // Return the view corresponding to the current action with the appropriate ViewData
            return new ViewResult
            {
                ViewName = actionName,
                ViewData = viewData
            };
        }
    }
}