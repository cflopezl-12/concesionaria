using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAppConcesionaria.Models
{
    public class VehiculoDTO
    {
        [BsonId]
        public ObjectId Vehiculo { get; set; }

        public string? Marca { get; set; }

        public string? Linea { get; set; }

        public int Modelo { get; set; }

        public string? Motor { get; set; }

        public double Precio { get; set; }

    }
}
