using AutoMapper;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;
using TwoFactorAuthenticator.Models.Entity;
using TwoFactorAuthenticator.Models.Model;

namespace TwoFactorAuthenticator.Dependency.AutoMapper
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<TokenModel, Token>().ReverseMap();
        }
    }
}
