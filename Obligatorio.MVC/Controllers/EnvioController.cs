using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.MVC.Filtros;
using Obligatorio.MVC.Models;

namespace Obligatorio.MVC.Controllers
{
    public class EnvioController : Controller
    {
        private ICUAltaEnvio _CUAltaEnvio;
        private ICUObtenerEnvios _CUObtenerEnvios;
        private ICUObtenerAgencias _CUObtenerAgencias;
        private ICUObtenerEnvio _CUObtenerEnvio;
        private ICUFinalizarEnvio _CUFinalizarEnvio;

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUObtenerEnvios cUObtenerEnvios, ICUObtenerAgencias cUObtenerAgencias, ICUObtenerEnvio cUObtenerEnvio, ICUFinalizarEnvio cUFinalizarEnvio)
        {
            _CUAltaEnvio = cuAltaEnvio;
            _CUObtenerEnvios = cUObtenerEnvios;
            _CUObtenerAgencias = cUObtenerAgencias;
            _CUObtenerEnvio = cUObtenerEnvio;
            _CUFinalizarEnvio = cUFinalizarEnvio;
        }

        [LogueadoAuthorize]
        public IActionResult Index()
        {
            return View(_CUObtenerEnvios.ObtenerEnvios());
        }

        [LogueadoAuthorize]
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();

            foreach (var agencia in _CUObtenerAgencias.ObtenerAgencias())
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = agencia.Id.ToString(),
                    Text = agencia.Nombre
                    
                };
                vm.Agencias.Add(selectListItem);
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                int lId = (int)HttpContext.Session.GetInt32("LogueadoId");
                vm.Dto.IdFuncionario = lId;
                _CUAltaEnvio.AltaEnvio(vm.Dto);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

            return View(vm);
        }

        [LogueadoAuthorize]
        public IActionResult FinalizarEnvio(int id)
        {
            var envio = _CUObtenerEnvio.ObtenerEnvio(id);
            return View(envio);
        }
        [HttpPost, ActionName("FinalizarEnvio")]
        [LogueadoAuthorize]
        public IActionResult FinalizarEnvioConfirmed(int id)
        {
            try
            {
                _CUFinalizarEnvio.FinalizarEnvio(id);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }
    }
}
