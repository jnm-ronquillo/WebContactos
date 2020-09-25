using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebContactos.Context;
using WebContactos.Models;

namespace WebContactos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IMongoContactDBContext _context;
        protected IMongoCollection<Contacto> _dbCollection;

        public ContactoController(IMongoContactDBContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Contacto>(typeof(Contacto).Name);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Contacto>>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<Contacto>.Filter.Empty);
            return Ok(all.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contacto contacto)
        {
            if (contacto == null)
            {
                throw new ArgumentNullException(typeof(Contacto).Name + " object is null");
            }

            if(contacto.Id != null)
            {
                var objectId = new ObjectId(contacto.Id);
                await _dbCollection.ReplaceOneAsync(Builders<Contacto>.Filter.Eq("_id", objectId), contacto);
                return Ok();
            }
            contacto.shardkey = "jm";
            contacto.ContactoId = "3";
            //contacto.Id = new ObjectId(contacto.Id); ;
            //_dbCollection = _context.GetCollection<Contacto>(typeof(Contacto).Name);
            await _dbCollection.InsertOneAsync(contacto);
            return Ok(HttpStatusCode.Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var objectId = new ObjectId(id);
            await _dbCollection.DeleteOneAsync(Builders<Contacto>.Filter.Eq("_id", objectId));
            return Ok();
        }

    }
}
