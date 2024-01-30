using ProyectoCrud.BLL.Services.Interfaces;
using ProyectoCrud.DAL.Repositories.Interfaces;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository<Contacto> _contactoRepository;
        public ContactoService(IContactoRepository<Contacto> contactRepository)
        {
            _contactoRepository=contactRepository;
        }
        public async Task<bool> Actualizar(Contacto modelo)
        {
            return await _contactoRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactoRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            return await _contactoRepository.Insertar(modelo);
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _contactoRepository.Obtener(id);
        }

        public async Task<Contacto> ObtenerPorNombre(string nombreContacto)
        {
            IQueryable<Contacto> queryContactoSQL = await _contactoRepository.ObtenerTodos();
            Contacto contacto = queryContactoSQL.Where(c => c.Nombre == nombreContacto).FirstOrDefault();
            return contacto;
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            return await _contactoRepository.ObtenerTodos();
        }
    }
}
