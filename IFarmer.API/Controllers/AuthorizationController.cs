using IFarmer.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace IFarmer.API.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationController(
            IOptions<IdentityOptions> identityOptions,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _identityOptions = identityOptions;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("~/connect/token")]
        [Produces("application/json")]
        public async Task<IActionResult> Exchange(AuthConnectRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Username) ?? await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                return BadRequest(new AuthConnectResponse
                {
                    ErrorDescription = "Please check that your email and password is correct"
                });
            }

            // Validate the username/password parameters and ensure the account is not locked out.
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            // Ensure the user is not already locked out.
            if (result.IsLockedOut)
            {
                return BadRequest(new AuthConnectResponse
                {
                    ErrorDescription = "The specified user account has been suspended"
                });
            }

            // Reject the token request if two-factor authentication has been enabled by the user.
            if (result.RequiresTwoFactor)
            {
                return BadRequest(new AuthConnectResponse
                {
                    ErrorDescription = "Invalid login procedure"
                });
            }

            // Ensure the user is allowed to sign in.
            if (result.IsNotAllowed)
            {
                return BadRequest(new AuthConnectResponse
                {
                    ErrorDescription = "The specified user is not allowed to sign in"
                });
            }

            if (!result.Succeeded)
            {
                return BadRequest(new AuthConnectResponse
                {
                    ErrorDescription = "Please check that your email and password is correct"
                });
            }

            AuthenticationTicket ticket = null;

            // Create a new authentication ticket.
            ticket = await CreateTicketAsync(request, user);

            return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpPost("~/connect/ext")]
        public  IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback),"Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider,redirectUrl);
            return Challenge(properties,provider);
        }

        [AllowAnonymous]
        [HttpGet("~/connect/ex1")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info==null) return null;

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,false,true);

            return RedirectToAction(returnUrl);
        }

        private async Task<AuthenticationTicket> CreateTicketAsync(AuthConnectRequest request, ApplicationUser user)
        {
            // Create a new ClaimsPrincipal containing the claims that
            // will be used to create an id_token, a token or a code.
            var principal = await _signInManager.CreateUserPrincipalAsync(user);

            // Create a new authentication ticket holding the user identity.
            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), CookieAuthenticationDefaults.AuthenticationScheme);

            return ticket;
        }
    }
}