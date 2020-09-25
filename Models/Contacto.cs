using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactos.Models
{
    public class Contacto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ContactoId { get; set; }
        public string Distrito { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }

        public string shardkey { get; set; }
    }
}
