using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : Controller
    {
        private IBaseService<Jogador> _baseJogadorService;

        public JogadorController(IBaseService<Jogador> baseJogadorService)
        {
            _baseJogadorService = baseJogadorService;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _baseJogadorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            return Execute(() => _baseJogadorService.GetById(id));
        }

        [HttpPost]
        public IActionResult NovoTime([FromBody] Jogador jogador)
        {
            if (jogador == null)
                return NotFound();

            return Execute(() => _baseJogadorService.Add<JogadorValidator>(jogador).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]Jogador jogador)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (jogador == null)
                return NotFound();

            return Execute(() => _baseJogadorService.Update<JogadorValidator>(jogador, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _baseJogadorService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
