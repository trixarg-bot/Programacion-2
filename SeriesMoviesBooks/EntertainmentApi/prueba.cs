using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class prueba : ControllerBase
{
    // GET: api/test
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "API is working!";
    }
}
