﻿using AutoMapper;
using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.Entities;
using money_management_service.Extentions;

namespace money_management_service.MappingProfiles
{
    public class MoneyManagementMapping : Profile
    {
        public MoneyManagementMapping() 
        {
            CreateMap<ExpenseType, ExpenseTypeDTO>()
                .ForMember(dest => dest.StatusName, act => act.MapFrom(src => src.Status.GetDescription()))
                .ReverseMap();

            CreateMap<MoneyStorage, MoneyStorageDTO>()
                .ForMember(dest => dest.StatusName, act => act.MapFrom(src => src.Status.GetDescription()))
                .ForMember(dest => dest.CardTypeName, act => act.MapFrom(src => src.CardType.GetDescription()))
                .ReverseMap();
        }
    }
}
