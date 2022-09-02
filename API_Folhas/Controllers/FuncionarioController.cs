using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        // GET: /api/funcionario/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() => Ok(funcionarios);

        // POST: /api/funcionario/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Created("", funcionario);
        }

        // GET: /api/funcionario/buscar/123
        [Route("buscar/{cpf}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            //Expressão lambda
            Funcionario funcionario = funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            //IF ternário
            return funcionario != null ? Ok(funcionario) : NotFound();
        }

        // DELETE: /api/funcionario/deletar/123
        [Route("deletar/{cpf}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] string cpf)
        {
            Funcionario funcionario = funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            if (funcionario != null)
            {
                funcionarios.Remove(funcionario);
                return Ok(funcionario);
            }
            return NotFound();
        }

        // PATCH: /api/funcionario/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Funcionario funcionario)
        {
            Funcionario funcionarioBuscado = funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(funcionario.Cpf)
            );
            if (funcionarioBuscado != null)
            {
                funcionarioBuscado.Nome = funcionario.Nome;
                return Ok(funcionario);
            }
            return NotFound();
        }
    }
}


// if (funcionario != null)
// {
//     return Ok(funcionario);
// }
// return NotFound();
// foreach (Funcionario f in funcionarios)
// {
//     if(f.Cpf.Equals(cpf))
//     {
//         return Ok(f);
//     }
// }