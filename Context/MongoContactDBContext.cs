using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace WebContactos.Context
{
    public class MongoContactDBContext : IMongoContactDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoContactDBContext(IOptions<Mongosettings> configuration)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(configuration.Value.Connection)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            
            /*MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(configuration.Value.Host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(configuration.Value.DatabaseName, configuration.Value.Username);
            MongoIdentityEvidence evidence = new PasswordEvidence(configuration.Value.Password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);
            */

            _mongoClient = new MongoClient(settings);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
