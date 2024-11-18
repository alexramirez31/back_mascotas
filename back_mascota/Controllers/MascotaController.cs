using back_mascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace back_mascota.Controllers
{
    [EnableCors(origins: "*", headers:"*",methods:"GET,POST,PUT,DELETE,OPTIONS")]
    public class MascotaController : ApiController
    {
        // GET: api/Macota
        public IEnumerable<Mascota> Get()
        {
            GestorMascota gMascota = new GestorMascota();
            return gMascota.GetMascotas();
        }

        // GET: api/Macota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Macota
        public bool Post([FromBody]Mascota mascota)
        {
            GestorMascota gMascota = new GestorMascota();
            bool res = gMascota.addMascota(mascota);

            return res;
        }

        // PUT: api/Macota/5
        public bool Put(int id, [FromBody] Mascota mascota)
        {
            GestorMascota gMascota = new GestorMascota();
            bool res = gMascota.updateMascota(id,mascota);

            return res;
        }

        // DELETE: api/Macota/5
        public bool Delete(int id)
        {
            GestorMascota gMascota = new GestorMascota();
            bool res = gMascota.deleteMascota(id);

            return res;

        }
    }
}
