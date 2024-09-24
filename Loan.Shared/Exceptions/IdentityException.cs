using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace Loan.Shared.Exceptions
{
    public class IdentityException : Exception
    {
        public IEnumerable<IdentityError> IdentityErrors { get; }

        public IdentityException(IEnumerable<IdentityError> errors)
            : base("One or more identity errors occurred.")
        {
            IdentityErrors = errors;
        }
    }

    public class UserNotFoundException : Exception
    {
        public string Username { get; }

        public UserNotFoundException(string username)
            : base($"User '{username}' cannot be found.")
        {
            Username = username;
        }
    }

    public class InvalidCredentialsException : Exception
    {
        public string Username { get; }

        public InvalidCredentialsException(string username)
            : base($"Wrong username or password for user '{username}'.")
        {
            Username = username;
        }
    }
}