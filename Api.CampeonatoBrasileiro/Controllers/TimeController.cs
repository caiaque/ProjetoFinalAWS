using CampeonatoBrasileiro.Domain.DTOs;
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
        private readonly ITimeRepository _timeRepository;

        public TimeController(IBaseService<Time> baseTimeService, ITimeRepository timeRepository)
        {
            _baseTimeService = baseTimeService;
            this._timeRepository = timeRepository;
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
        public IActionResult NovoTime([FromBody] TimeDto time)
        {
            if (time == null)
                return NotFound();

            return Execute(() => this._timeRepository.Add(time));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]TimeDto time)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (time == null)
                return NotFound();

            return Execute(() => this._timeRepository.Update(time, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            try
            {
                _baseTimeService.Delete(id);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
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
