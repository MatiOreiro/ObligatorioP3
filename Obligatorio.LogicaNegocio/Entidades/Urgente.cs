using Obligatorio.LogicaNegocio.Enumerados.EnvioEnums;
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

        public Urgente() { }
        public Urgente(int nroTracking, Usuario funcionario, Usuario cliente, decimal peso, EstadoEnvio estado, string direccion, string valor) : base(nroTracking, funcionario, cliente, peso, estado)
        {
            Direccion = direccion;
            Valor = valor;
        }


    }
}
