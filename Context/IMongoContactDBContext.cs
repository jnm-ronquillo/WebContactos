using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactos.Models;

namespace WebContactos.Context
{
    public interface IMongoContactDBContext
    {
        IMongoCollection<Contacto> GetCollection<Contacto>(string name);
    }
}
