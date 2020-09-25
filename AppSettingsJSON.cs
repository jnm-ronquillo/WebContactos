using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactos
{

    public class Rootobject
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Mongosettings MongoSettings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Mongosettings
    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
