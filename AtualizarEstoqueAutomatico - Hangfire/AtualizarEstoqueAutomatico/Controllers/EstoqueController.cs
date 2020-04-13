using Microsoft.AspNetCore.Mvc;

namespace AtualizarEstoqueAutomatico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}