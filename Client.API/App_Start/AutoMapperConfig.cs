using Application.Client.Dtos;
using AutoMapper;
using Domain.Client.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Client.API.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestClientDto, ClientEntity>().ReverseMap()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdIdentificationType, opt => opt.MapFrom(src => src.IdTipoIdentifiacion))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identificacion))
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.LastNames, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Celular))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<RequestClientDto, HomeEntity>().ReverseMap()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.IdCity, opt => opt.MapFrom(src => src.IdCiudad))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<ClientEntity, RequestClientDto>().ReverseMap()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdClient))
                .ForMember(dest => dest.IdTipoIdentifiacion, opt => opt.MapFrom(src => src.IdIdentificationType))
                .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Identification))
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.LastNames))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Mobile))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<ClientEntity, CreateClientResponseDto>().ReverseMap()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdClient))
                .ForMember(dest => dest.CupoTotal, opt => opt.MapFrom(src => src.TotalSpace))
                .ForMember(dest => dest.CupoDisponible, opt => opt.MapFrom(src => src.AvailableSpace))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<CreateClientResponseDto, ClientEntity>().ReverseMap()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.TotalSpace, opt => opt.MapFrom(src => src.CupoTotal))
                .ForMember(dest => dest.AvailableSpace, opt => opt.MapFrom(src => src.CupoDisponible))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<HomeEntity, RequestClientDto>().ReverseMap()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdClient))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.IdCiudad, opt => opt.MapFrom(src => src.IdCity))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<ClientEntity, ClientDataResponse>().ReverseMap()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdClient))
                .ForMember(dest => dest.IdTipoIdentifiacion, opt => opt.MapFrom(src => src.IdIdentificationType))
                .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Identification))
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.LastNames))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Mobile))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
            CreateMap<ClientDataResponse, ClientEntity>().ReverseMap()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdIdentificationType, opt => opt.MapFrom(src => src.IdTipoIdentifiacion))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identificacion))
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.LastNames, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Celular))
                .ForMember(dest => dest.TotalSpace, opt => opt.MapFrom(src => src.CupoTotal))
                .ForMember(dest => dest.AvailableSpace, opt => opt.MapFrom(src => src.CupoDisponible))
                .ForAllMembers(opts => opts.PreCondition((src, dest, srcMember)
                  => srcMember != null && !string.IsNullOrWhiteSpace(srcMember?.ToString())));
        }
    }
}
