using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TattooStudio.Data.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
