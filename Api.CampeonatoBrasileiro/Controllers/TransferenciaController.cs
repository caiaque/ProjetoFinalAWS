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
    public class TransferenciaController : Controller
    {
        private IBaseService<Transferencia> _baseTransferenciaService;

        public TransferenciaController(IBaseService<Transferencia> baseTransferenciaService)
        {
            _baseTransferenciaService = baseTransferenciaService;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _baseTransferenciaService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            return Execute(() => _baseTransferenciaService.GetById(id));
        }

        [HttpPost]
        public IActionResult NovoTime([FromBody] Transferencia transferencia)
        {
            if (transferencia == null)
                return NotFound();

            return Execute(() => _baseTransferenciaService.Add<TransferenciaValidator>(transferencia).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]Transferencia transferencia)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            if (transferencia == null)
                return NotFound();

            return Execute(() => _baseTransferenciaService.Update<TransferenciaValidator>(transferencia, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _baseTransferenciaService.Delete(id);
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
