using AutoMapper;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;

namespace money_management_service.Services
{
    public class ExpenseTypeService : BaseService<ExpenseType, ExpenseTypeDTO>, IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IExpenseTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
