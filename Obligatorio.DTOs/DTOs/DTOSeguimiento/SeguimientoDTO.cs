using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOSeguimiento
{
    public class SeguimientoDTO
    {
        public int Id { get; set; }
        public string NombreFuncionario { get; set; }
        public string ApellidoFuncionario { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public SeguimientoDTO(string nombreFuncionario, string apellidoFuncionario, string comentario, DateTime fecha)
        {
            NombreFuncionario = nombreFuncionario;
            ApellidoFuncionario = apellidoFuncionario;
            Comentario = comentario;
            Fecha = fecha;
        }
        public SeguimientoDTO()
        {
        }
    }
}
