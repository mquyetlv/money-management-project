using AutoMapper;
using money_management_service.DTOs.ExpenseType;
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
        }
    }
}
