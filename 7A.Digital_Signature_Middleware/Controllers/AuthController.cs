using Microsoft.AspNetCore.Mvc;

namespace _7A.Digital_Signature_Middleware.Controllers;

[Route("[controller]")]
public class AuthController : ControllerBase
{
    public AuthController()
    {

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(CancellationToken cancellationToken)
    {
        return Ok();
    }
}
