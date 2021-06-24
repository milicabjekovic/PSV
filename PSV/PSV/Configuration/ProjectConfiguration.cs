using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public string FrontendURL { get; set; }
        public int PayrollStartID { get; set; }
        public string FieldPowerDataApiKey { get; set; }
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();
        //public EmailSettings Emailsettings { get; set; } = new EmailSettings();
        public Jwt Jwt { get; set; } = new Jwt();
    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

    public class EmailSettings
    {
        public string IP { get; set; }
        public bool UseLocal { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string SMTP { get; set; }
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }

    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
