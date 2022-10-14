using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using API_Folhas.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<FolhaPagamento> folhas =
                _context.Folhas.Include(f => f.Funcionario).ToList();

            if (folhas.Count == 0) return NotFound();

            return Ok(folhas);
            // return folhas.Count != 0 ? Ok(folhas) : NotFound();
        }

        // GET: /api/funcionario/buscar/{cpf}/{mes}/{ano}
        [HttpGet]
        [Route("buscar/{cpf}/{mes}/{ano}")]
        public IActionResult Buscar(
            [FromRoute] string cpf, int mes, int ano
        ) =>
            Ok(_context.Folhas
                .Include(f => f.Funcionario)
                .FirstOrDefault(
                    f =>
                    f.Funcionario.Cpf.Equals(cpf) &&
                    f.Mes == mes &&
                    f.Ano == ano
                ));

        // GET: /api/funcionario/filtrar/{mes}/{ano}
        [HttpGet]
        [Route("filtrar/{mes}/{ano}")]
        public IActionResult Filtrar(
            [FromRoute] int mes, int ano
        ) =>
            Ok(_context.Folhas
                .Include(f => f.Funcionario)
                .Where(
                    f =>
                    f.CriadoEm.Month == mes &&
                    f.CriadoEm.Year == ano
                ));

    }
}