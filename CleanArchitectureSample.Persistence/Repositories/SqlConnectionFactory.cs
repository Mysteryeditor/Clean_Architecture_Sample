﻿using CleanArchitectureSample.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Persistence.Repositories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("myconnection"));
        }
    }
}
