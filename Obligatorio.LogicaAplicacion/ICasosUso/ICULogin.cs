using Obligatorio.DTOs.DTOs.DTOUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso
{
    public interface ICULogin
    {
        UsuarioDTO VerificarDatosParaLogin(UsuarioDTO dto);

    }
}
