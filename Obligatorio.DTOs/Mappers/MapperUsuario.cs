using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enumerados.UsuarioEnums;
using Obligatorio.LogicaNegocio.VO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTOUsuarioToUsuario(DTOAltaUsuario dto)
        {

            var r = Roles.Administrador;

            if (dto.Rol.Equals(1))
            {
                r = Roles.Funcionario;
            }

            string passHashed = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 12);


            Usuario ret = new Usuario(new NombreCompleto(dto.Nombre, dto.Apellido), dto.Email, passHashed, r);

            return ret;

        }
    }
}
