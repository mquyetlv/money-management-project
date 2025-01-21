using Microsoft.AspNetCore.Mvc;
using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace money_management_service.Controllers
{
    public class ExpenseTypeController : BaseController
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService) 
        {
            _expenseTypeService = expenseTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse<List<ExpenseTypeDTO>>>> GetAll([FromQuery] SearchExpenseTypeDTO searchData)
        {
            QueryModel<ExpenseType> queryModel = new QueryModel<ExpenseType>()
            {
                Filters = new List<Expression<Func<ExpenseType, bool>>>
                {
                    expenseType => expenseType.Name.Contains(searchData.Name ?? ""),
                    expenseType => expenseType.Description.Contains(searchData.Description ?? ""),
                    expenseType => searchData.IsBalanceChanged == null ? true : expenseType.IsBalanceChanged == searchData.IsBalanceChanged,
                }
            };

            queryModel.Page = searchData.Page;
            queryModel.Size = searchData.Size;

            APIResponse<List<ExpenseTypeDTO>> dataResponse = await _expenseTypeService.GetAllAsync(queryModel);
            return Ok(dataResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<APIResponse<ExpenseTypeDTO>>> GetById(int id)
        {
            APIResponse<ExpenseTypeDTO> data = await _expenseTypeService.GetById(id);
            if (data == null)
            {
                return BadRequest(new APIResponse<ExpenseTypeDTO>(HttpStatusCode.BadRequest, $"Expense with id {id} not found!"));
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<ExpenseTypeDTO>>> CreateExpensiveType([FromBody] CreateExpenseTypeDTO expenseType)
        {
            var data = await _expenseTypeService.Create(expenseType);
            return Ok(data);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<APIResponse<string>>> Delete(int id)
        {
            bool isDeleteSuccess = await _expenseTypeService.Delete(id);
            if (isDeleteSuccess)
            {
                return Ok(new APIResponse<string>($"Delete Expense Type {id} successfully!"));
            }

            return BadRequest(new APIResponse<string>($"Expense Type {id} not found!"));
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<APIResponse<ExpenseTypeDTO>>> Update([FromRoute] int id, [FromBody] CreateExpenseTypeDTO expenseType) 
        { 
            APIResponse<ExpenseTypeDTO> dataResponse = await _expenseTypeService.Update(id, expenseType);
            if (dataResponse == null) 
            {
                return BadRequest(new APIResponse<string>(HttpStatusCode.BadRequest, $"Update Expense Type with id {id} failure!"));
            }

            return Ok(dataResponse);
        }
    }
}
 