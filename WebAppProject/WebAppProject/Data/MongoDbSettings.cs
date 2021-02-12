using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProject.Data
{
        public class MongoDbSettings : IMongoDbSettings
        {
            public string DrinksCollection { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IMongoDbSettings
        {
            string DrinksCollection { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
}
