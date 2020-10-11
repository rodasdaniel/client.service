using Application.Client.Dtos;
using System.Net;
using System.Threading.Tasks;

namespace Application.Client.Business.Client
{
    public interface IClientBusiness
    {
        Task<(HttpStatusCode statusCode, string message, ClientDataResponse response)>
            GetClientAsync(int idType, string identification);
        Task<(HttpStatusCode statusCode, string message, CreateClientResponseDto createClientResponseDto)>
            CreateClientAsync(RequestClientDto requestClientDto);
    }
}
