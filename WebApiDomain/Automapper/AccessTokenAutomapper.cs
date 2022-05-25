using AutoMapper;

namespace WebApiDomain.Automapper
{
    public class AccessTokenAutomapper : Profile
    {
        public AccessTokenAutomapper()
        {
            CreateMap<WebApi.DTO.AccessTokenRequest, Model.AccessTokenRequest>();
        }
    }
}
