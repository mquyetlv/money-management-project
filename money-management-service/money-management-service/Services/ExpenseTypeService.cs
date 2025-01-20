using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;
using money_management_service.Respository.Interfaces;
using money_management_service.Services.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace money_management_service.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _repository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IExpenseTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse<ExpenseTypeDTO>> Create(CreateExpenseTypeDTO createDto)
        {
            ExpenseType expenseType = new ExpenseType()
            {
                Name = createDto.Name,
                Description = createDto.Description,
                IsBalanceChanged = createDto.IsBalanceChanged,
            };

            try
            {
                var result = await _repository.CreateAsync(expenseType);
                ExpenseTypeDTO expenseTypeDTO = _mapper.Map<ExpenseTypeDTO>(expenseType);
                return new APIResponse<ExpenseTypeDTO>(expenseTypeDTO);
            }
            catch (Exception ex) 
            {
                return new APIResponse<ExpenseTypeDTO>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<APIResponse<List<ExpenseTypeDTO>>> GetAllAsync(QueryModel<ExpenseType> queryModel)
        {
            try
            {
                APIResponse<List<ExpenseType>> data = await _repository.GetAllAsync(queryModel);
                return new APIResponse<List<ExpenseTypeDTO>>(_mapper.Map<List<ExpenseTypeDTO>>(data.Data), data.Pagination);
            }
            catch (Exception ex)
            {
                return new APIResponse<List<ExpenseTypeDTO>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<APIResponse<string>> Delete(int id)
        {
            try
            {
                bool isDeleteSuccess = await _repository.DeleteAsync(id);
                if (isDeleteSuccess)
                {
                    return new APIResponse<string>($"Deleted expense type {id} successfully.");
                }
                else
                {
                    return new APIResponse<string>($"Cam not delete expense type {id}!");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public Task<APIResponse<ExpenseTypeDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<ExpenseTypeDTO>> Update(int id, ExpenseTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
