using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Repositories.Interfaces;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class ContactoRepository : IContactoRepository<Contacto>
    {
        private readonly DbpruebasContext _dbpruebasContext;
        public ContactoRepository(DbpruebasContext context)
        {
            _dbpruebasContext = context;
        }

        public async Task<bool> Actualizar(Contacto modelo)
        {
            _dbpruebasContext.Contactos.Update(modelo);
            await _dbpruebasContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Contacto modelo = _dbpruebasContext.Contactos.First(c=>c.IdContacto == id);
            _dbpruebasContext.Contactos.Remove(modelo);
            return true;
        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            _dbpruebasContext.Contactos.Add(modelo);
            await _dbpruebasContext.SaveChangesAsync();
            return true;
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _dbpruebasContext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            IQueryable<Contacto> queryContactoSQL = _dbpruebasContext.Contactos;
            return queryContactoSQL;
        }
    }
}
