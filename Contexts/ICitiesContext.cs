using Auto_complete_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auto_complete_server.Contexts
{
    public interface ICitiesContext
    {
        Task<IEnumerable<GetCitiesResult>> GetCities(string characters);
    }
}
