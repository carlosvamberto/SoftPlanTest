using Microsoft.AspNetCore.Mvc;

namespace ApiTaxaJuros.Controllers
{
    [Route("/taxaJuros")]
    [ApiController]
    public class TaxaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(0.01M);        
    }
}
