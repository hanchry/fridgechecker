using AutoMapper;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;

namespace fridgechecker.Utilities.Mapper;

public class FridgeCheckerMapper:Profile
{
    public FridgeCheckerMapper()
    {
        //----- HouseHold -----//
        CreateMap<HouseHoldDB, HouseHold>().ReverseMap();
    }
    
}