using Microsoft.AspNetCore.Mvc;

namespace BasicDDDSample.API.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    public abstract class PublicApiController : ControllerBase
    {
    }
}
