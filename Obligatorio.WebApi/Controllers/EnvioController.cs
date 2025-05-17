using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private ICUObtenerEnvioPorTracking _CUObtenerEnvioPorTracking;
        private ICUObtenerComentarios _CUObtenerComentarios;
        public EnvioController(ICUObtenerEnvioPorTracking cUObtenerEnvioPorTracking, ICUObtenerComentarios cUObtenerComentarios)
        {
            _CUObtenerEnvioPorTracking = cUObtenerEnvioPorTracking;
            _CUObtenerComentarios = cUObtenerComentarios;
        }
        [HttpGet("{nroTracking}")]
        public IActionResult GetEnvioPorTracking(int nroTracking)
        {
            EnvioDTO envio = _CUObtenerEnvioPorTracking.ObtenerEnvioPorTracking(nroTracking);
            envio.Seguimiento = _CUObtenerComentarios.ObtenerComentarios(envio.Id);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);
        }
    }
}
