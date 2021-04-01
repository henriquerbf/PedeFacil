using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Log")]
    public class LogController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<object> Select()
        {
            RepLog rep = new RepLog();
            return rep.Select();
        }

        [HttpPut]
        [Route("Insert")]
        public bool Enviar(Log log)
        {
            if (log == null)
            {
                return false;
            }
            RepLog RepLog = new RepLog();

            return RepLog.Enviar(log);
        }
    }
}