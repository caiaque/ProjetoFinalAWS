using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        private const string PARTIDAS_KEY = "Partidas";
        public PartidaController(IBaseService<PartidaTorneio> basePartidaTorneioService, IMemoryCache cache)
        {
            _basePartidaTorneioService = basePartidaTorneioService;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult ObterTodoAsPartidas()
        {
            if(_cache.TryGetValue(PARTIDAS_KEY, out List<PartidaTorneio> partidas))
            {
                return Ok(partidas);
            }

            var cacheExpiracao = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5400),
                SlidingExpiration = TimeSpan.FromSeconds(2700)
            };

            return _cache.Set(PARTIDAS_KEY, Execute(() => _basePartidaTorneioService.GetAll()), cacheExpiracao);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPartidaPorId(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            return Execute(() => _basePartidaTorneioService.GetById(id));
            
        }

        [HttpPost]
        public IActionResult NovoPartida([FromBody] PartidaTorneio jogador)
        {
            if (jogador == null)
                return NotFound();
            _cache.Remove(PARTIDAS_KEY);
            return Execute(() => _basePartidaTorneioService.Add<PartidaValidator>(jogador).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PartidaTorneio jogador)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (jogador == null)
                return NotFound();

            return Execute(() => _basePartidaTorneioService.Update<PartidaValidator>(jogador, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
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
