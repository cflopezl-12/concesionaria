using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehiculo
    {

        [BsonId]
        public ObjectId Id { get; set; }

        public string? Marca { get; set; }

        public string? Linea { get; set; }

        public int? Modelo { get; set; }

        public string? Motor {  get; set; }

        public double? Precio { get; set; }

    }
}
