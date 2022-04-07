using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : Controller
    {
        private IBaseService<PartidaTorneio> _basePartidaTorneioService;

        public PartidaController(IBaseService<PartidaTorneio> basePartidaTorneioService)
        {
            _basePartidaTorneioService = basePartidaTorneioService;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _basePartidaTorneioService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            return Execute(() => _basePartidaTorneioService.GetById(id));
        }

        [HttpPost]
        public IActionResult NovoTime([FromBody] PartidaTorneio jogador)
        {
            if (jogador == null)
                return NotFound();

            return Execute(() => _basePartidaTorneioService.Add<PartidaValidator>(jogador).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PartidaTorneio jogador)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            if (jogador == null)
                return NotFound();

            return Execute(() => _basePartidaTorneioService.Update<PartidaValidator>(jogador, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _basePartidaTorneioService.Delete(id);
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
