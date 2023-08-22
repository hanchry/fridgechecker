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
        
        //----- Storage -----//
        CreateMap<StorageDB, Storage>().ReverseMap();
        
        //----- User -----//
        CreateMap<UserDB, User>().ReverseMap();
        
        //----- Food -----//
        CreateMap<FoodDB, Food>().ReverseMap();
        
        //----- Dish -----//
        CreateMap<DishDB, Dish>().ReverseMap();
    }
    
}