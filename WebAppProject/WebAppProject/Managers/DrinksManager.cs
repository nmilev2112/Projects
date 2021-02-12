using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProject.Data;
using WebAppProject.Data.DTO;
using WebAppProject.Managers.Interfaces;

namespace WebAppProject.Managers
{
    public class DrinksManager : IDrinksManager
    {
        private readonly IMongoCollection<Drink> _drinks;
        public DrinksManager(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            _drinks = database.GetCollection<Drink>(mongoDbSettings.DrinksCollection);
        }
        public Drink GetByName(string name)
        {
            var drink = _drinks.Find<Drink>(x => x.drink_name == name).FirstOrDefault();
            return drink;
        }

        public List<Drink> GetAll()
        {
            var drinks = _drinks.Find(x => true).ToList();
            return drinks;
        }
    }
}
