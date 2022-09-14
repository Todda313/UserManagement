using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = API.DataModel;
using API.Domain;
using AutoMapper;

namespace API.Profiles
{
  public class AutoMapper : Profile
  {
    public AutoMapper()
    {

      CreateMap<UserRequest, DataModel.AppUser>();

    }
  }
}