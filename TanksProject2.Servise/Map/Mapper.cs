using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.TankModel.TankComponents;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.Servise.Map
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Firepower, FirepowerDtos>();
            CreateMap<Mobility, MobilityDtos>();
            CreateMap<Observation, ObservationDtos>();
            CreateMap<User, UserDtos>();
            
        }
    }
}
