using Application.Client.Dtos;
using AutoMapper;
using Domain.Client.Entities;
using Infrastructure.Client.Data.Repository;
using System.Net;
using System.Threading.Tasks;
using static Application.Client.Common.Resources.Messages;

namespace Application.Client.Business.Client
{
    public class ClientBusiness : IClientBusiness
    {
        #region Constructor
        private readonly IClientRepository _clientsRepository;
        private readonly IMapper _mapper;
        private readonly IHomeRepository _homeRepository;

        public ClientBusiness(IClientRepository clientsRepository,
            IHomeRepository homeRepository,
            IMapper mapper)
        {
            _clientsRepository = clientsRepository;
            _homeRepository = homeRepository;
            _mapper = mapper;
        }

        public IHomeRepository HomeRepository { get; }
        #endregion
        public async Task<(HttpStatusCode statusCode, string message, CreateClientResponseDto createClientResponseDto)>
            CreateClientAsync(RequestClientDto requestClientDto)
        {
            ClientEntity clientEntity = null;
            if (ValidateClientExist(requestClientDto.IdIdentificationType,
                requestClientDto.Identification, ref clientEntity))
            {
                return (HttpStatusCode.BadRequest, ClientExistMsg, null);
            }
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

        public async Task<(HttpStatusCode statusCode, string message, InfoClientResponseDto createClientResponseDto)>
            GetInfoClientAsync(long idClient)
        {
            ClientEntity clientEntity = _clientsRepository.GetById(idClient).Result;
            if (clientEntity == null)
            {
                return (HttpStatusCode.NoContent, ClientNoExistMsg, null);
            }
            else
            {
                return (HttpStatusCode.OK, SuccessMsg, _mapper.Map<InfoClientResponseDto>(clientEntity));
            }
        }
        #region Private
        private void CreateHome(long idClient, RequestClientDto requestClientDto)
        {
            requestClientDto.IdClient = idClient;
            _homeRepository.Create(_mapper.Map<HomeEntity>(requestClientDto));
        }
        private bool ValidateClientExist(int idType, string identification, ref ClientEntity clientEntity)
        {
            clientEntity = _clientsRepository.GetById(idType, identification).Result;
            return clientEntity != null;
        }
        private void CreateClient(RequestClientDto requestClientDto, ref ClientEntity clientEntity)
        {
            clientEntity = _mapper.Map<ClientEntity>(requestClientDto);
            clientEntity.CupoTotal = 2000000;
            clientEntity.CupoDisponible = 2000000;
            clientEntity.IdCliente = _clientsRepository.Create(clientEntity).Result;
        }
        #endregion
    }
}
