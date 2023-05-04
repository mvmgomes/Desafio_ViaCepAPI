using Microsoft.AspNetCore.Mvc;
using ViaCepApi.Business;

namespace ViaCepAPI.App.Controllers
{
    public class ViaCepController : ControllerBase
    {
        
        [HttpGet("BuscarCep")]
        public IActionResult BuscarCep(string cep)
        {
            var service = new FluxoAPIControll();
            var result = service.ConectaAPI(cep);
            return Ok(result);
        }
    }
}
