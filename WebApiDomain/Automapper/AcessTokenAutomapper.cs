using AutoMapper;
using WebApi.DTO;
using WebApiDomain.Model;

namespace WebApiDomain.Automapper
{
    public class AcessTokenAutomapper : Profile
    {
        public AcessTokenAutomapper()
        {
            CreateMap<AccessTokenRequest, AccessToken>();
        }
    }
}
