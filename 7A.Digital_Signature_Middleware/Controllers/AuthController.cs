using _7A.Digital_Signature_Middleware.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace _7A.Digital_Signature_Middleware.Controllers;

[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(CancellationToken cancellationToken)
    {
        _authService.Login("MPKI_BVQY7A_QK7", "3sDf1kd5");

        return Ok();
    }
}
