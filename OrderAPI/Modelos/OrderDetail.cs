

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Modelos
{
    [Serializable,BsonIgnoreExtraElements]
    
    public class OrderDetail
    {
        [BsonElement("product_id"),BsonRepresentation(BsonType.Int32)]
        
        public int ProductId { get; set; }

        [BsonElement("quantity"),BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }

        [BsonElement("uni_price"),BsonRepresentation(BsonType.Decimal128)]
        public DateTime OrderedOn { get; set; }
        
    }
}
