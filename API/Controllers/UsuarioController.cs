using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //GET: /api/usuario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok("Vamos para casa!");
        }
    }
}