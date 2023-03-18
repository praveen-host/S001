using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Extensions.Options;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DbAccess
{
    public class DapperContext
    {
        
        private readonly string _connectionString;
        public DapperContext(IOptions<AppConfig> _appConfig)
        {
            _connectionString = $"Server={_appConfig.Value.HostIp};Port={_appConfig.Value.Port};Database={_appConfig.Value.Database};Uid={_appConfig.Value.UserName};Pwd={_appConfig.Value.Password};";
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);

         
    }
}
