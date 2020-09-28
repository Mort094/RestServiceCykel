using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CykelLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceCykel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CykelsController : ControllerBase
    {
        private static List<Cykel> cykels = new List<Cykel>()
        {
            new Cykel(1, "rød", 200, 16),
            new Cykel(2, "grå", 100, 8),
            new Cykel(3, "blå", 50, 3),
            new Cykel(4, "sort", 500, 32),
            new Cykel(5, "gul", 200, 32)

        };
        // GET: api/Cykels
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return cykels;
        }

        // GET: api/Cykels/5
        [HttpGet("{id}")]
        [EnableCors("AllowAnyOrigin")]
        public Cykel Get(int id)
        {
            return cykels.Find(i => i.Id == id);
        }

        // POST: api/Cykels
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public string Post([FromBody] Cykel value)
        {
            cykels.Add(value);
            return $"Ny cykel er lavet med id : {value.Id} ";
        }

        // PUT: api/Cykels/5
        [HttpPut("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
            {
                cykel.Id = value.Id;
                cykel.Farve = value.Farve;
                cykel.Pris = value.Pris;
                cykel.Gear = value.Gear;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [DisableCors]
        public void Delete(int id)
        {
            Cykel cykel = Get(id);
            cykels.Remove(cykel);

        }
    }
}
