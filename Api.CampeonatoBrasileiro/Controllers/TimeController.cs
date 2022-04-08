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
    public class TimeController : Controller
    {
        private IBaseService<Time> _baseTimeService;

        public TimeController(IBaseService<Time> baseTimeService)
        {
            _baseTimeService = baseTimeService;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _baseTimeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            return Execute(() => _baseTimeService.GetById(id));
        }

        [HttpPost]
        public IActionResult NovoTime([FromBody] Time time)
        {
            if (time == null)
                return NotFound();

            return Execute(() => _baseTimeService.Add<TimeValidator>(time).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Time time)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (time == null)
                return NotFound();

            return Execute(() => _baseTimeService.Update<TimeValidator>(time, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _baseTimeService.Delete(id);
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
