using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orderCollection;
        public OrderController()
        {
            var dbHost = "localHost";
            var dbName = "dms_order";
            var connectionString = $"mongodb://{dbHost}:5160/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");

        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }

        // GET api/<OrderController>
        [HttpGet("{orderid}")]
        public async Task<ActionResult<Order>> GetById(string orderId)
        {
            var filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            return await _orderCollection.Find(filterDefinition).SingleOrDefaultAsync();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        { 
            await _orderCollection.InsertOneAsync(order);
            return Ok();

        }

        // PUT api/<OrderController>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Order order) 
        {
            var fiterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId); 
            await _orderCollection.ReplaceOneAsync(fiterDefinition, order);
            return Ok();
        }

        // DELETE api/<OrderController>
        [HttpDelete("{orderid}")]
        public async Task<ActionResult> Delete(string orderId)
        {
            var fiterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            await _orderCollection.DeleteOneAsync(fiterDefinition);
            return Ok();
        }
    }
}
