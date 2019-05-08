using AutoMapper;
using EvaluationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Infraestructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ImageEntity, Image>()
              .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                Link.To(
                    nameof(Controllers.ImageController.GetImageById),
                    new { imageId = src.Id })));

            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                    Link.To(nameof(Controllers.UsersController.GetUserById),
                    new { userId = src.Id })));



        }
    }
}
