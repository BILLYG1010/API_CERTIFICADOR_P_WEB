using AutoMapper;
using Certificador.CBL.Api.v1;
using Certificador.DAL.Api;
using Certificador.DAL.Api.Entities;
using Certificador.DTO.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificador.BLL.Api.v1
{
    public class ClienteAPIBL : IClienteAPIBL
    {
        private readonly CERTIFICADORContext _certificadoContext;
        private readonly IMapper _mapper;

        public ClienteAPIBL(CERTIFICADORContext certificadoContext, IMapper mapper)
        {
            _certificadoContext = certificadoContext;
            _mapper = mapper;
        }

        public async Task<ClienteAPIDTO> ActualizarCliente(ClienteAPIDTO cliente)
        {
            var cliente1 = _mapper.Map<ClienteAPI>(cliente);
            cliente.ActualizadoEn = DateTime.Now;
            cliente.EstadoCliente = true;
            _certificadoContext.ClienteAPI.Update(cliente1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<ClienteAPIDTO>(cliente1);
        }

        public async Task<ClienteAPIDTO> CrearCliente(ClienteAPIDTO cliente)
        {
            var cliente1 = _mapper.Map<ClienteAPI>(cliente);
            cliente.CreadoEn = DateTime.Now;
            cliente.ActualizadoEn = DateTime.Now;
            cliente1.EstadoCliente = true;
            _certificadoContext.ClienteAPI.Add(cliente1);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<ClienteAPIDTO>(cliente1);
        }

        public async Task<ClienteAPIDTO> EliminarCliente(int IdCliente)
        {
            var cliente = await _certificadoContext.ClienteAPI
                           .FirstOrDefaultAsync(x => x.IdCliente == IdCliente && x.EstadoCliente == true);
            if (cliente == null)
                return new ClienteAPIDTO();

            cliente.EstadoCliente = false;
            cliente.ActualizadoEn = DateTime.Now;
            _certificadoContext.ClienteAPI.Update(cliente);
            await _certificadoContext.SaveChangesAsync();
            return _mapper.Map<ClienteAPIDTO>(cliente);
        }

        public async Task<ClienteAPIDTO> ObtenerPorId(int id)
        {
            var cliente = await _certificadoContext.ClienteAPI
                .Where(x => x.IdCliente == id).FirstOrDefaultAsync();

            return _mapper.Map<ClienteAPIDTO>(cliente);
        }
        public async Task<List<ClienteAPIDTO>> ObtenerTodos()
        {
            var listadoClientes = await _certificadoContext.ClienteAPI
                .Where(x => x.EstadoCliente == true).ToListAsync();

            return _mapper.Map<List<ClienteAPIDTO>>(listadoClientes);
        }
    }
}