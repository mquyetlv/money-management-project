using Microsoft.AspNetCore.Mvc;
using money_management_service.DTOs.ExpenseType;
using money_management_service.Services.Interfaces;

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
        public async Task<IActionResult> GetAll(SearchExpenseTypeDTO searchCondition) 
        {
            const queryModel = new QueryModel
        }
    }
}
 