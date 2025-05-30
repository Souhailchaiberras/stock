﻿using Microsoft.AspNetCore.Mvc;
using API2.Data;
using API2.Mappers;
using API2.Dtos.Stock;
using API2.Models;
using Microsoft.EntityFrameworkCore;
using API2.Interface;
using API2.Helpers;
namespace API2.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDBCContext _context;
        private readonly IStockRepository _stockrepo;
        public StockController(ApplicationDBCContext context,IStockRepository stockrepo)
        {
            _stockrepo = stockrepo;
            _context = context;
        }
        [HttpGet]
        public async  Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            
                return BadRequest(ModelState);
            
            var stocks = await _stockrepo.GetAllAsync(query);
                var stockDto=stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockrepo.GetByIdAsync(id);
            if (stock == null) {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpGet("name/{name}")]
        public IActionResult GetByName([FromRoute] string name) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _context.Stock.Include(c=>c.Comments).FirstOrDefault(stock => stock.Companyname == name);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());

        }
        [HttpGet("symbole/{symbole}")]
        public IActionResult GetBysymbole([FromRoute] string symbole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _context.Stock.Include(c => c.Comments).FirstOrDefault(stock => stock.Symbol == symbole);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);

        }
        [HttpGet("industry/{industry}")]
        public IActionResult GetByIndustry([FromRoute] string industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _context.Stock.FirstOrDefault(stock => stock.Industry == industry);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);

        }

        [HttpGet("purchace/{purchace}")]
        public IActionResult GetByPurchace([FromRoute] decimal purchace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _context.Stock.Where(stock => stock.Purchace == purchace).ToList();
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);

        }
        [HttpPost]
        public async Task<IActionResult>  create([FromBody] CreateStockRequest stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDto();
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetById),
                new { id = stockModel.Id },
                stockModel.ToStockDto()
            );
        }
        [HttpPut("{id}")]
        public async  Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDTO stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockrepo.updateAsync(id,stockDto);
            
            return Ok(stockModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockmodel = await _stockrepo.deleteAsync(id);
           
            return NoContent();

        }
        

    }

    
}
