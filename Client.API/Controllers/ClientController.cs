using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using Application.Client.Common.Handler;
using Application.Client.Dtos;
using Client.API.Filters.ValidateModel;
using Application.Client.Business.Client;

namespace Client.API.Controllers
{
    /// <summary>
    /// Controlador encargado de realizar las operaciones del Cliente
    /// </summary>
    [Route("api/[controller]/v1")]
    [ApiController]
    [ProducesResponseType(typeof(HttpResponseException), 500)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 400)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 401)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 404)]
    [ValidateModel]
    public class ClientController : ControllerBase
    {
        #region Constructor
        private readonly IClientBusiness _clientsBusiness;
        public ClientController(IClientBusiness clientsBusiness)
        {
            _clientsBusiness = clientsBusiness;
        }
        #endregion
        /// <summary>
        /// Método a través del cual se realiza la creación de un nuevo registro de Cliente.
        /// </summary>
        /// <param name="requestClientDto">Representa los datos específicos del Cliente, necesarios para realizar el registro.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(HttpResponseDto<CreateClientResponseDto>), 200)]
        public async Task<IActionResult> Create([FromBody] RequestClientDto requestClientDto)
        {
            (HttpStatusCode statusCode, string message, CreateClientResponseDto response) =
                await _clientsBusiness.CreateClientAsync(requestClientDto);
            if (statusCode != HttpStatusCode.NoContent && Response != null)
            {
                Response.StatusCode = (int)statusCode;
            }
            return ServiceAnswer<CreateClientResponseDto>.Response(statusCode, message, response);
        }

        /// <summary>
        /// Método a través del cual se obtienen los datos de un Cliente específico.
        /// </summary>
        /// <param name="idIdentificationType">Representa el identificador único del tipo de identificación del Cliente.</param>
        /// <param name="identification">Representa el número de identificación del Cliente.</param>
        /// <returns></returns>
        [HttpGet("{idIdentificationType}/{identification}")]
        [ProducesResponseType(typeof(HttpResponseDto<ClientDataResponse>), 200)]
        public async Task<IActionResult> Get(int idIdentificationType, string identification)
        {
            (HttpStatusCode statusCode, string message, ClientDataResponse response) =
                await _clientsBusiness.GetClientAsync(idIdentificationType, identification);
            if (statusCode != HttpStatusCode.NoContent && Response != null)
            {
                Response.StatusCode = (int)statusCode;
            }
            IActionResult actionResult = ServiceAnswer<ClientDataResponse>.Response(statusCode, message, response);
            return actionResult;
        }

        /// <summary>
        /// Método a través del cual se obtiene la información del Cliente necesaria para la realización de un crédito.
        /// </summary>
        /// <param name="idClient">Representa el identificador único del registro del cliente.</param>
        /// <returns></returns>
        [HttpGet("GetInfoClient/{idClient}")]
        [ProducesResponseType(typeof(HttpResponseDto<InfoClientResponseDto>), 200)]
        public async Task<IActionResult> GetInfoClient(long idClient)
        {
            (HttpStatusCode statusCode, string message, InfoClientResponseDto response) =
                await _clientsBusiness.GetInfoClientAsync(idClient);
            if (statusCode != HttpStatusCode.NoContent && Response != null)
            {
                Response.StatusCode = (int)statusCode;
            }
            return ServiceAnswer<InfoClientResponseDto>.Response(statusCode, message, response);
        }
    }
}
