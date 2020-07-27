using AutoMapper;
using MinhaApi.Api.ViewModels;
using MinhaApi.Business.Models;

namespace MinhaApi.Api.Extensions
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
