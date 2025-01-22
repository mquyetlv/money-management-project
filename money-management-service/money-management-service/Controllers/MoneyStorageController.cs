using Microsoft.AspNetCore.Mvc;
using money_management_service.Core;
using money_management_service.DTOs.MoneyStorage;
using money_management_service.Entities;
using money_management_service.Services.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace money_management_service.Controllers
{
    public class MoneyStorageController : BaseController
    {
        private readonly IMoneyStorageService _service;

        public MoneyStorageController(IMoneyStorageService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MoneyStorageDTO>>> GetAll([FromQuery] SearchMoneyStorageDTO searchInfo)
        {
            QueryModel<MoneyStorage> queryModel= new QueryModel<MoneyStorage>()
            {
                Filters = new List<Expression<Func<MoneyStorage, bool>>>()
                {
                    moneyStorage => moneyStorage.Name.Contains(searchInfo.Name ?? ""),
                    moneyStorage => moneyStorage.CardNumber.Contains(searchInfo.CardNumber ?? ""),
                    moneyStorage => moneyStorage.OwnerName.Contains(searchInfo.OwnerName ?? ""),
                    moneyStorage => searchInfo.CardType == null ? true : moneyStorage.CardType == searchInfo.CardType,
                }
            };

            return Ok(await _service.GetAllAsync(queryModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse<MoneyStorageDTO>>> GetById([FromRoute] int id)
        {
            APIResponse<MoneyStorageDTO> data = await _service.GetById(id);
            if (data == null)
            {
                return BadRequest(new APIResponse<MoneyStorageDTO>(HttpStatusCode.BadRequest, $"Money storage with id {id} not found"));
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<MoneyStorageDTO>>> Create([FromBody] CreateMoneyStorageDTO createMoneyStorageDto)
        {
            return Ok(await _service.Create(createMoneyStorageDto));
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
        public async Task<ActionResult<APIResponse<MoneyStorageDTO>>> Update([FromRoute] int id, [FromBody] CreateMoneyStorageDTO createMoneyStorage)
        {
            APIResponse<MoneyStorageDTO> data = await _service.Update(id, createMoneyStorage);
            if (data == null) 
            { 
                return BadRequest(new APIResponse<MoneyStorageDTO>(HttpStatusCode.BadRequest, $"Money storage with id {id} not found")); 
            }

            return Ok(data);
        }
    }
}
