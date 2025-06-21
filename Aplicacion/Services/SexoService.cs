using Dominio.Contracts.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Models;
using Dominio.Contracts.Repositorios;

namespace Aplicacion.Services
{
    public class SexoService : ISexoService
    {
        private readonly ISexoRepository _sexoRepository;
        public SexoService(ISexoRepository sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }
        public async Task<List<Sexo>> GetAll()
        {
            return await _sexoRepository.GetAll();
        }
    }
    
}
