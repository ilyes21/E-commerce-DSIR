using AutoMapper;
using E_commerce_DSIR.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_DSIR.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile() {
            CreateMap<IdentityRole, GetRolesViewModel>();
        }
    }
}
