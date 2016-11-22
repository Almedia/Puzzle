using AutoMapper;
using Puzzle.Infrastructure.Data.Model;

namespace Puzzle.Infrastructure.Mapping
{
    public class AutoMapperProfileConfiguration:Profile
    {
        protected  override void Configure(){
                CreateMap<User,Puzzle.Core.Model.User>();
        }
    }
}