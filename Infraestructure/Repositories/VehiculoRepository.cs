using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private IMongoCollection<Vehiculo> Collection;

        public VehiculoRepository(IStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            Collection = database.GetCollection<Vehiculo>(settings.VehiculoCollectionName);
        }

        public async Task DeleteEntity(string id)
        {
            var filter = Builders<Vehiculo>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public FilterDefinition<Vehiculo> SetFindFilter(string marca, string linea, string precio)
        {
            var builder = Builders<Vehiculo>.Filter;
            var filter = builder.Empty;
            if (marca != null && marca.Length > 2)
            {
                filter &= Builders<Vehiculo>.Filter.Eq("Marca", marca);
            }
            if (linea != null && linea.Length > 2)
            {
                filter &= Builders<Vehiculo>.Filter.Eq("Linea", linea);
            }
            if (precio != null && precio.Length > 2)
            {
                filter &= Builders<Vehiculo>.Filter.Gte("Precio", Double.Parse(precio));
            }
            return filter;
        }

        public async Task<List<Vehiculo>> GetCustom(string marca, string linea, string precio)
        {
            return await Collection.FindAsync(SetFindFilter(marca, linea, precio)).Result.ToListAsync();
        }

        public async Task<List<Vehiculo>> GetEntityAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            
        }

        public async Task<Vehiculo> GetEntityById(string id)
        {
            return await Collection.FindAsync(
                                                new BsonDocument { { "_id", new ObjectId(id) } }
                                             ).Result.FirstAsync();
        }

        public async Task InsertEntity(Vehiculo Entity)
        {
            await Collection.InsertOneAsync(Entity);
        }

        public async Task UpdateEntity(Vehiculo Entity)
        {
            var filter = Builders<Vehiculo>
                            .Filter
                            .Eq(s => s.Id, Entity.Id);
            await Collection.ReplaceOneAsync(filter, Entity);
        }

    }
}
