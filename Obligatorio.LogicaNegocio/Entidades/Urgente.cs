using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Urgente : Envio
    {
        public string Direccion { get; set; }
        public string Valor { get; set; }
        public Urgente(string direccion, string valor)
        {
            Direccion = direccion;
            Valor = valor;
        }
    }
}
