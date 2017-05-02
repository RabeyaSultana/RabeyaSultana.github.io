using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HRManagementSystem.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            HRMSContext db = new HRMSContext();

            var user = db.EmployeeLogins.Where(d => d.Email == context.UserName).FirstOrDefault();
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.UserPassword))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                if (context.UserName == user.Email && context.Password == user.UserPassword)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                    identity.AddClaim(new Claim("username", user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    var uid = new Dictionary<string, string>() { { "userid", user.loginId.ToString() }, { "role", user.UserRole.ToString() } };

                    var ticket = new AuthenticationTicket(identity, new AuthenticationProperties(uid));

                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "Username and Password Combination Provided is Incorrect!");
                    return;
                }
            }
        }
    }
}