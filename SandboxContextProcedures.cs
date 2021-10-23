﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Auto_complete_server;

namespace Auto_complete_server
{
    public partial class SandboxContext
    {
        private SandboxContextProcedures _procedures;

        public SandboxContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new SandboxContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public SandboxContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class SandboxContextProcedures
    {
        private readonly SandboxContext _context;

        public SandboxContextProcedures(SandboxContext context)
        {
            _context = context;
        }

        public virtual async Task<List<GetCitiesResult>> GetCitiesAsync(string Characters, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Characters",
                    Size = -1,
                    Value = Characters ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetCitiesResult>("EXEC @returnValue = [dbo].[GetCities] @Characters", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
