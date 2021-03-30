using PedeFacilAPI.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Comanda")]
    public class ComandaController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<object> Select()
        {
            RepComanda rep = new RepComanda();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Comanda comanda)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("comanda", "id_Comanda", comanda.id_Comanda);

            RepComanda RepComanda = new RepComanda();
            var resultado = RepComanda.Enviar(comanda, retorno);
            banco.Fechar();

            return resultado;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete_Comanda(Comanda Comanda)
        {
            RepComanda RepComanda = new RepComanda();
            return RepComanda.Delete(Comanda);
        }
    }
}