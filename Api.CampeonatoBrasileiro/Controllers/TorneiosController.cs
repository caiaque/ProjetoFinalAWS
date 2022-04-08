using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Mensageiro.Interfaces;
using CampeonatoBrasileiro.Service.Validators;
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
    public class TorneiosController : Controller
    {
        private IBaseService<Torneio> _baseTorneioService;
        private ISend _send;
        private IBaseService<PartidaTorneio> _basePartidaService;
        private readonly IMemoryCache _cache;
        private const string PARTIDAS_KEY = "Partidas";

        public TorneiosController(IBaseService<Torneio> baseTorneioService, ISend send, IBaseService<PartidaTorneio> basePartidaService, IMemoryCache cache)
        {
            _baseTorneioService = baseTorneioService;
            _send = send;
            _basePartidaService = basePartidaService;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult ObterTodosOsTimes()
        {
            return Execute(() => _baseTorneioService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ObterTimePorId(Guid id)
        {
            if (id == Guid.Empty)
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
            if (id == Guid.Empty)
                return NotFound();

            if (transferencia == null)
                return NotFound();

            return Execute(() => _baseTorneioService.Update<TorneioValidator>(transferencia, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            Execute(() =>
            {
                _baseTorneioService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/inicio")]
        public IActionResult InicioPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Partida {partidaId} iniciada.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/gol")]
        public IActionResult GolPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Gol relaizado na partida {partidaId}.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }
        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/intervalo")]
        public IActionResult IntervaloPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Intervalo da partida {partidaId} iniciado.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }
        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/acrescimo/{acrescimo}")]
        public IActionResult AcrescimoPartida(Guid torneioId, Guid partidaId,int acrescimo)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. {acrescimo} minutos de acréscimo adcionado na partida {partidaId}.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }
        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/substituicao")]
        public IActionResult SubstituicaoPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Substituição  realaizada na partida {partidaId}.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }
        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/advertencia")]
        public IActionResult AdvertenciaPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Advertência recebida na partida {partidaId}.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                return true;
            });

            return new NoContentResult();
        }
        [HttpPost]
        [Route("{torneioId}/partidas/{partidaId}/eventos/fim")]
        public IActionResult FimPartida(Guid torneioId, Guid partidaId)
        {
            if (torneioId == null || torneioId == Guid.Empty)
                return NotFound();

            if (partidaId == null || partidaId == Guid.Empty)
                return NotFound();

            string mensagem = $"Torneio {torneioId}. Partida {partidaId} finalizada.";

            Execute(() =>
            {
                this._send.EnviarMensagem(mensagem);
                this._basePartidaService.Delete(partidaId);
                _cache.Set(PARTIDAS_KEY, Execute(() => _basePartidaService.GetAll()));
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
