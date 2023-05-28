using Hotel_MVC.Models;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace Hotel_MVC.Services
{
    public class ApartmanService : IApartmanService
    {
        private readonly IMongoCollection<Apartman> _apartmani;

        public ApartmanService(IApartmanStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _apartmani = database.GetCollection<Apartman>(settings.HotelCollectionName);
        }

        public Apartman Create(Apartman apartman)
        {
            _apartmani.InsertOne(apartman);
            return apartman;
        }

        public List<Apartman> Get()
        {
            return _apartmani.Find(apartman => true).ToList();
        }

        public Apartman Get(string id)
        {
            return _apartmani.Find(apartman => apartman.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _apartmani.DeleteOne(apartman => apartman.Id == id);
        }

        public void Update(string id, Apartman aparatman)
        {
            _apartmani.ReplaceOne(apartman => apartman.Id == id, aparatman);
        }
    }
}
