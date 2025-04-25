using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void AltaFuncionario(DTOAltaUsuario dto)
        {
            try
            {
                Usuario buscado = _repoUsuario.FindByEmail(dto.Email);
                if (buscado != null)
                {
                    throw new EmailYaExisteException("Este email ya existe");
                }


                Usuario nuevo = MapperUsuario.FromDTOUsuarioToUsuario(dto);
                int idEntidad = _repoUsuario.Add(nuevo);

                Auditoria aud = new Auditoria(dto.LogueadoId, "ALTA", nuevo.GetType().Name, idEntidad.ToString(), "Alta correcta" + JsonSerializer.Serialize(nuevo));

                _repoAuditoria.Auditar(aud);
            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(dto.LogueadoId, "ALTA", "Usuario", null, "ERROR: " + e.Message);

                _repoAuditoria.Auditar(aud);
                throw e;
            }
        }
    }
    {
    }
}
