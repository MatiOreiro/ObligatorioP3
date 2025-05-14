using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUObtenerEnvios cUObtenerEnvios, ICUObtenerAgencias cUObtenerAgencias)
        {
            _CUAltaEnvio = cuAltaEnvio;
            _CUObtenerEnvios = cUObtenerEnvios;
            _CUObtenerAgencias = cUObtenerAgencias;
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
    }
}
