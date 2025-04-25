using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ApplicationDbContext _context;

        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Envio> FindAll()
        {
            return _context.Envios.ToList();
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Where(a => a.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int id)
        {
            // cambiar el envio de en proceso a finalizado
            Envio e = _context.Envios.Where(x => x.Id == id).SingleOrDefault();
            _context.Envios.Remove(e);
            _context.SaveChanges();
        }

        public int Update(Envio obj)
        {
            // agregar un comentario al envio
            _context.Envios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
    }
}
