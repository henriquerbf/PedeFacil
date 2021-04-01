using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("SAC_Log")]
    public class SacLogController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<SAC_Log> Select()
        {
            RepSacLog rep = new RepSacLog();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(SAC_Log sac_log)
        {
            if (sac_log == null)
            {
                return false;
            }
            RepSacLog RepSacLog = new RepSacLog();

            return RepSacLog.Enviar(sac_log);
        }
    }
}