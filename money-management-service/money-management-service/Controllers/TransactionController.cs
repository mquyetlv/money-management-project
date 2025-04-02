using Microsoft.AspNetCore.Mvc;
using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.DTOs.Transaction;
using money_management_service.DTOs.TransactionType;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace money_management_service.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _service;

        public TransactionController (ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionDTO>>> GetAll([FromQuery] SearchTransactionDTO searchInfo)
        {
            QueryModel<Transaction> queryModel = new QueryModel<Transaction>()
            {
                Filters = new List<Expression<Func<Transaction, bool>>>()
                {
                    transaction => transaction.Name.Contains(searchInfo.Name ?? ""),
                    transaction => transaction.Description.Contains(searchInfo.Description ?? ""),
                    transaction => searchInfo.Amount != null
                                        ? transaction.Amount == searchInfo.Amount
                                        : true,
                    transaction => searchInfo.TransactionTypeId != null
                                        ? transaction.TransactionTypeId == searchInfo.TransactionTypeId
                                        : true,
                    transaction => searchInfo.MoneyStorageId != null
                                        ? transaction.MoneyStorageId == searchInfo.MoneyStorageId
                                        : true,
                },
                Includes = new List<Expression<Func<Transaction, object>>>()
                {
                    transaction => transaction.TransactionType,
                    transaction => transaction.MoneyStorage,
                },
            };

            return Ok(await _service.GetAllAsync(queryModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse<TransactionDTO>>> GetById([FromRoute] int id)
        {
            APIResponse<TransactionDTO> data = await _service.GetById(id);
            if (data == null)
            {
                return BadRequest(new APIResponse<TransactionDTO>(HttpStatusCode.BadRequest, $"Transaction type with id {id} not found"));
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<TransactionDTO>>> Create([FromBody] CreateTransactionDTO createTransactionDTO)
        {
            return Ok(await _service.Create(createTransactionDTO));
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
        public async Task<ActionResult<APIResponse<TransactionDTO>>> Update([FromRoute] int id, [FromBody] CreateTransactionDTO createTransactionDTO)
        {
            APIResponse<TransactionDTO> data = await _service.Update(id, createTransactionDTO);
            if (data == null)
            {
                return BadRequest(new APIResponse<TransactionDTO>(HttpStatusCode.BadRequest, $"Transaction type with id {id} not found"));
            }

            return Ok(data);
        }
    }
}
