using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using MyApi;
using Train.Models;
using Train.Repositories;

namespace Train.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemsRepository _repository;

        public ItemController(ItemsRepository _repository)
        {
            this._repository = _repository;
        }

        //Get /items
        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            var items =(await _repository.GetItemsAsync())
                                .Select(r => r.AsDTO());
            return items;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            return item.AsDTO();
        }

        //Add /items
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> AddItemAsync(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
           await _repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync),new {id = item.Id},item.AsDTO());
        }

        //Update /items
        [HttpPut("id")]
        public async Task<ActionResult<UpdateItemDTO>> UpdateItemAsync(Guid id,UpdateItemDTO itemDTO)
        {
            var exisItem = await _repository.GetItemAsync(id);
            if(exisItem == null)
            {
                return NotFound();
            }
            Item updateItem = exisItem with
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price,
            };
            await _repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        //Delete /items
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var exisItem = await _repository.GetItemAsync(id);
            if(exisItem == null)
            {
                return NotFound();
            }
           await _repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}