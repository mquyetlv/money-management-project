using Microsoft.AspNetCore.Mvc;
using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.DTOs.TransactionType;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace money_management_service.Controllers
{
    public class TransactionTypeController : BaseController
    {
        private readonly ITransactionTypeService _service;

        public TransactionTypeController (ITransactionTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionTypeDTO>>> GetAll([FromQuery] SearchTransactionTypeDTO searchInfo)
        {
            QueryModel<TransactionType> queryModel = new QueryModel<TransactionType>()
            {
                Filters = new List<Expression<Func<TransactionType, bool>>>()
                {
                    transactionType => transactionType.Name.Contains(searchInfo.Name ?? ""),
                    transactionType => transactionType.Description.Contains(searchInfo.Description ?? ""),
                    transactionType => searchInfo.ExpenseTypeId != null
                                        ? transactionType.ExpenseTypeId == searchInfo.ExpenseTypeId
                                        : true,
                },
                Includes = new List<Expression<Func<TransactionType, object>>>()
                {
                    transaction => transaction.ExpenseType,
                },
            };

            return Ok(await _service.GetAllAsync(queryModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse<TransactionTypeDTO>>> GetById([FromRoute] int id)
        {
            APIResponse<TransactionTypeDTO> data = await _service.GetById(id);
            if (data == null)
            {
                return BadRequest(new APIResponse<TransactionTypeDTO>(HttpStatusCode.BadRequest, $"Transaction type with id {id} not found"));
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<TransactionTypeDTO>>> Create([FromBody] CreateTransactionTypeDTO createTransactionTypeDTO)
        {
            return Ok(await _service.Create(createTransactionTypeDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete([FromRoute] int id)
        {
            bool result = await _service.Delete(id);
            if (result)
            {
                return Ok(new APIResponse<string>(HttpStatusCode.OK, $"Delete money storage with id {id} successfully!"));
            }

            return BadRequest(new APIResponse<string>(HttpStatusCode.BadRequest, $"Delete money storage with id {id} failure!"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse<MoneyStorageDTO>>> Update([FromRoute] int id, [FromBody] CreateTransactionTypeDTO createTransactionTypeDTO)
        {
            APIResponse<TransactionTypeDTO> data = await _service.Update(id, createTransactionTypeDTO);
            if (data == null)
            {
                return BadRequest(new APIResponse<TransactionTypeDTO>(HttpStatusCode.BadRequest, $"Transaction type with id {id} not found"));
            }

            return Ok(data);
        }
    }
}
