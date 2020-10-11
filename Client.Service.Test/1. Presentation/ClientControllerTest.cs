using Application.Client.Business.Client;
using Application.Client.Dtos;
using AutoMapper;
using Client.API.App_Start;
using Client.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Client.Service.Test
{
    public class ClientControllerTest
    {
        #region Constructor

        ClientController _controller;
        IClientBusiness _service;

        public ClientControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _service = new ClientBusinessTest(mapper);
            _controller = new ClientController(_service);
        }
        #endregion 
        [Fact]
        public void CreateClientAsync()
        {
            var actionResult = _controller.Create(new RequestClientDto
            {
                IdCity = 1,
                Address = "Calle angosta 123",
                IdIdentificationType = 1,
                Identification = "321654",
                Names = "Test Value Name",
                LastNames = "Test Values LastName",
                Mobile = "3111111111",
                Email = "test@siste.com"

            }).Result as ObjectResult;
            var result = actionResult.Value as HttpResponseDto<CreateClientResponseDto>;
            Assert.NotNull(result);
            Assert.Equal(200, result.Code);
            var clientData = result.Object;
            Assert.NotNull(clientData);
            Assert.IsType<CreateClientResponseDto>(clientData);
        }
        [Fact]
        public void GetClientAsync()
        {
            var actionResult = _controller.Get(1, "12344").Result as ObjectResult;
            var result = actionResult.Value as HttpResponseDto<ClientDataResponse>;
            Assert.NotNull(result);
            Assert.Equal(200, result.Code);
            var clientData = result.Object;
            Assert.NotNull(clientData);
            Assert.IsType<ClientDataResponse>(clientData);
        }
    }
}
