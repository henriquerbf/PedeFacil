using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("SAC_Protocolo")]
    public class SacProtocoloController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<object> Select()
        {
            RepSacProtocolo rep = new RepSacProtocolo();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(SAC_Protocolo sac_protocolo)
        {
            if (sac_protocolo == null)
            {
                return false;
            }
            RepSacProtocolo RepSacProtocolo = new RepSacProtocolo();

            return RepSacProtocolo.Enviar(sac_protocolo);
        }
    }
}