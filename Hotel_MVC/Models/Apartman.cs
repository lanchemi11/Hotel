using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hotel_MVC.Models
{
    public class Apartman
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("brojSobe")]
        public int BrojSobe { get; set; }

        [BsonElement("cena")]
        public int Cena { get; set; }

        [BsonElement("rezervisano")]
        public bool Rezervisano { get; set; }

        [BsonElement("slika")]
        public string Slika { get; set; } = String.Empty;

    }
}
