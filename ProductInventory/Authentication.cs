using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventory
{
    public sealed class Auth
    {
        private Auth()
        {
        }

        private static readonly Lazy<Auth> Lazy = new Lazy<Auth>(() => new Auth());
        public static Auth Instance => Lazy.Value;

        public int LoggedInUserId { get; set; }
    }

    public interface IAuthenticationService
    {
        void CheckLoggedInUser();
    }

    public class AuthenticationService : IAuthenticationService
    {
        public void CheckLoggedInUser()
        {
            Auth.Instance.LoggedInUserId.MustNotBeDefault("Error Authenticating");
        }
    }
}
