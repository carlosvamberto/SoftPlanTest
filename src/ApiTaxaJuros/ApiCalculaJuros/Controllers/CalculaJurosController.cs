using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCalculaJuros.Controllers
{
    [Route("/calculaJuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CalculaJurosAsync([FromQuery] decimal valorInical, int tempo)
        {
            decimal valorFinal = 0;
            decimal taxaJuros = 0;
            var client = new HttpClient();
            var response = await client.GetStringAsync("http://172.17.0.2:80/taxaJuros");
            //var result = await response.Content.ReadAsStringAsync();
            taxaJuros = decimal.Parse(response);

            valorFinal =  valorInical * (decimal)Math.Pow((double)(1 + taxaJuros), (double)tempo);

            // Truncar em duas casas decimais
            valorFinal = Math.Truncate(valorFinal * 100) / 100;

            return Ok(valorFinal);
        }
    }
}
