using AutoMapper;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;

namespace TwoFactorAuthenticator.Dependency.AutoMapper
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
