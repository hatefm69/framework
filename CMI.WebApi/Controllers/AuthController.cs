using FIS.ZarrirSecurity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMI.WebApi.Controllers
{
    [Route("core/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IZarrirAuthentication<AuthController> _zarrirAuthentication;

        // Constuctors.
        public AuthController(IZarrirAuthentication<AuthController> zarrirAuthentication)
        {
            _zarrirAuthentication = zarrirAuthentication;
            _zarrirAuthentication.Controller = this;
        }

        // Web APIs
        [HttpPost("[action]")]
        public async Task<IActionResult> Token()
            => await _zarrirAuthentication.Token();

        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Refresh(string token)
            => await _zarrirAuthentication.Refresh(token);

        [HttpGet("[action]")]
        public async Task<IActionResult> Callback()
            => await _zarrirAuthentication.CallBack();

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
            => await _zarrirAuthentication.Logout();

        [HttpPost("[action]")]
        public async Task<IActionResult> Sitemap()
            => await _zarrirAuthentication.SiteMap();

        [HttpGet]
        [Route("Version")]
        public IActionResult Version()
            => Ok("V 1.18.1");
    }
}
