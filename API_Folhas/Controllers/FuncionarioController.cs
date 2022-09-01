using System.Collections.Generic;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Folhas.Controllers
{

    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        [Route("listar")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarios);
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Created("", funcionario);
        }

        [Route("buscar/{cpf}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Cpf.Equals(cpf))
                {
                    return Ok(funcionarios[i]);
                }
            }
            return NotFound();
        }
    }
}