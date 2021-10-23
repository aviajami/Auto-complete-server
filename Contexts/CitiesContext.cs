using Auto_complete_server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auto_complete_server.Contexts
{
    public class CitiesContext : ICitiesContext
    {
        SandboxContext _sandboxContext;
        SandboxContextProcedures _sandboxContextProcedures;
        // readonly SandboxContext m_sandboxContext;
        public CitiesContext(SandboxContext sandboxContext)
        {
            _sandboxContext = sandboxContext;
            //_sandboxContext = new SandboxContext(service, dbContextOptions);
            _sandboxContextProcedures = new SandboxContextProcedures(_sandboxContext);
        }


        public async Task<IEnumerable<GetCitiesResult>> GetCities(string characters)
        {
            return await _sandboxContextProcedures.GetCitiesAsync(characters);
        }
    }
}
