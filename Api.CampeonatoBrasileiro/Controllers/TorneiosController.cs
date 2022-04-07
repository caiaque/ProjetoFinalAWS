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
    public class TorneiosController : Controller
    {
        private IBaseService<Torneio> _baseTorneioService;

        public TorneiosController(IBaseService<Torneio> baseTorneioService)
        {
            _baseTorneioService = baseTorneioService;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _baseTorneioService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            return Execute(() => _baseTorneioService.GetById(id));
        }

        [HttpPost]
        public IActionResult NovoTime([FromBody] Torneio torneio)
        {
            if (torneio == null)
                return NotFound();

            return Execute(() => _baseTorneioService.Add<TorneioValidator>(torneio).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Torneio transferencia)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            if (transferencia == null)
                return NotFound();

            return Execute(() => _baseTorneioService.Update<TorneioValidator>(transferencia, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _baseTorneioService.Delete(id);
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
