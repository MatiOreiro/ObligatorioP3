using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions
{
    public class UbicacionNoValidaException : Exception
    {
        public UbicacionNoValidaException(string message) : base(message)
        {
        }

    }
}
