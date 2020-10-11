using Application.Client.Business.Client;
using Application.Client.Dtos;
using AutoMapper;
using Domain.Client.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Application.Client.Common.Resources.Messages;

namespace Client.Service.Test
{
    public class ClientBusinessTest : IClientBusiness
    {
        #region Constructor
        private readonly IMapper _mapper;
        private List<ClientEntity> clients = new List<ClientEntity>();
        private List<HomeEntity> homes = new List<HomeEntity>();
        public ClientBusinessTest(IMapper mapper)
        {
            _mapper = mapper;
            for (int i = 1; i < 5; i++)
            {
                clients.Add(new ClientEntity
                {
                    IdCliente = i,
                    IdTipoIdentifiacion = 1,
                    Identificacion = $"1234{i}",
                    Nombres = $"Nombre {i}",
                    Apellidos = $"Apellido {i}",
                    Celular = $"311311311{i}",
                    Email = $"email_{i}@prueba.com",
                    CupoTotal = 2000000,
                    CupoDisponible = 2000000
                });
                homes.Add(new HomeEntity
                {
                    IdCliente = i,
                    IdCiudad = 1,
                    Direccion = $"Calle larga # 47 - {i}"
                });
            }
        }
        #endregion
        public async Task<(HttpStatusCode statusCode, string message, CreateClientResponseDto createClientResponseDto)>
            CreateClientAsync(RequestClientDto requestClientDto)
        {
            ClientEntity clientEntity = null;
            CreateClient(requestClientDto, ref clientEntity);
            CreateHome(clientEntity.IdCliente, requestClientDto);
            return (HttpStatusCode.OK, SuccessMsg, _mapper.Map<CreateClientResponseDto>(clientEntity));
        }

        public async Task<(HttpStatusCode statusCode, string message, ClientDataResponse response)>
            GetClientAsync(int idType, string identification)
        {
            ClientEntity clientEntity = null;
            if (!ValidateClientExist(idType, identification, ref clientEntity))
            {
                return (HttpStatusCode.NoContent, ClientNoExistMsg, null);
            }
            else
            {
                return (HttpStatusCode.OK, SuccessMsg, _mapper.Map<ClientDataResponse>(clientEntity));
            }
        }
        #region Private
        private void CreateHome(long idClient, RequestClientDto requestClientDto)
        {
            requestClientDto.IdClient = idClient;
            homes.Add(_mapper.Map<HomeEntity>(requestClientDto));
        }
        private bool ValidateClientExist(int idType, string identification, ref ClientEntity clientEntity)
        {
            clientEntity = clients.Where(c => c.IdTipoIdentifiacion == idType
            && c.Identificacion == identification).FirstOrDefault();
            return clientEntity != null;
        }
        private void CreateClient(RequestClientDto requestClientDto, ref ClientEntity clientEntity)
        {
            clientEntity = _mapper.Map<ClientEntity>(requestClientDto);
            clientEntity.CupoTotal = 2000000;
            clientEntity.CupoDisponible = 2000000;
            clients.Add(clientEntity);
            clientEntity.IdCliente = clients.Count;
        }
        #endregion
    }
}
