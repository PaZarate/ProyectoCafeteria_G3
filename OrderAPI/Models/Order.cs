using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [BsonElement("costumer_id"), BsonRepresentation(BsonType.Int32)]
        public string CostumerId { get; set; }

        [BsonElement("ordered_on"), BsonRepresentation(BsonType.DateTime)]
        public string OrderedOn { get; set; }

        [BsonElement("order_details")]

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
