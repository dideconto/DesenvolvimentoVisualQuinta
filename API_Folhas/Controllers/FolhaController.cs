using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using API_Folhas.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
        private readonly DataContext _context;
        public FolhaController(DataContext context) =>
            _context = context;


        // POST: /api/folha/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {
            folha.SalarioBruto =
                Calculos.CalcularSalarioBruto
                (folha.QuantidadeHoras, folha.ValorHora);

            folha.ImpostoRenda =
                Calculos.CalcularImpostoRenda(folha.SalarioBruto);

            folha.ImpostoInss =
                Calculos.CalcularImpostoInss(folha.SalarioBruto);

            folha.ImpostoFgts =
                Calculos.CalcularFgts(folha.SalarioBruto);

            folha.SalarioLiquido =
                Calculos.CalcularSalarioLiquido
                (
                    folha.SalarioBruto,
                    folha.ImpostoRenda,
                    folha.ImpostoInss
                );

            _context.Folhas.Add(folha);
            _context.SaveChanges();
            return Created("", folha);
        }

        // GET: /api/funcionario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<FolhaPagamento> folhas = _context.Folhas.ToList();

            if (folhas.Count == 0) return NotFound();

            return Ok(folhas);
            // return folhas.Count != 0 ? Ok(folhas) : NotFound();
        }
    }
}