using CostumerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly CostumerDbContext _costumerDbContext;

        public CostumerController(CostumerDbContext costumerDbContext)
        {
            _costumerDbContext = costumerDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Costumer>> GetCostumers()
        {
            return _costumerDbContext.Costumers;
        }

        [HttpGet("{costumerId:int}")]
        public async Task<ActionResult<Costumer>> GetById(int costumerId)
        {
            var costumer = await _costumerDbContext.Costumers.FindAsync(costumerId);
            return costumer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Costumer costumer)
        {
            await _costumerDbContext.Costumers.AddAsync(costumer);
            await _costumerDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Delete(int costumerId)
        {
            var costumer = await _costumerDbContext.Costumers.FindAsync(costumerId);
            _costumerDbContext.Costumers.Remove(costumer);
            await _costumerDbContext.SaveChangesAsync(true);
            return Ok();
        }
    }
}
