using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comun : Envio
    {
        public Agencia Agencia { get; set; }

        public Comun(Agencia agencia)
        {
            Agencia = agencia;
        }
    }
}
