using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Mesa")]
    public class MesaController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<object> Select()
        {
            RepMesa rep = new RepMesa();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Mesa mesa)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("Mesa", "id_Mesa", mesa.id_Mesa);

            RepMesa RepMesa = new RepMesa();
            var resultado = RepMesa.Enviar(mesa, retorno);
            banco.Fechar();

            return resultado;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(Mesa Mesa)
        {
            RepMesa RepMesa = new RepMesa();
            return RepMesa.Delete(Mesa);
        }
    }
}