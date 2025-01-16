using Microsoft.AspNetCore.Mvc;
using money_management_service.Core;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;
using System.Linq.Expressions;

namespace money_management_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseTypeController : ControllerBase
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
                    expenseType => searchData.IsBalanceChanged == null ? true: expenseType.IsBalanceChanged == searchData.IsBalanceChanged,
                }
            };
            APIResponse<List<ExpenseTypeDTO>> dataResponse = await _expenseTypeService.GetAllAsync(queryModel);
            return Ok(dataResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpensiveType([FromBody] ExpenseTypeDTO expenseType)
        {
            return Ok(_expenseTypeService.Create(expenseType));
        }
    }
}
 