using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso;

namespace Obligatorio.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ICULogin _CULogin;

        public UsuarioController(ICULogin CULogin)
        {
            _CULogin = CULogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO dto)
        {
            try
            {
                UsuarioDTO u = _CULogin.VerificarDatosParaLogin(dto);
                HttpContext.Session.SetInt32("LogueadoId", (int)u.Id);
                HttpContext.Session.SetString("LogueadoRol", u.Rol);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View();
            }

        }
    }
}
