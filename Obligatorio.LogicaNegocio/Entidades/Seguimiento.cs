using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Seguimiento
    {
        public Usuario Funcionario { get; init; }
        public string Comentario { get; init; }
        public DateTime Fecha { get; init; }
    }
}
