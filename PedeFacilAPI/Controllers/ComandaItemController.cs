using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Comanda_Item")]
    public class ComandaItemController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<Comanda_Item> Select()
        {
            RepComandaItem rep = new RepComandaItem();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Comanda_Item comanda_item)
        {
            //BancoTools banco = new BancoTools();
            //var retorno = banco.checa_existe("Mesa", "id_Comanda_Item", comanda_item.id_Comanda_Item);

            //RepComandaItem RepComandaItem = new RepComandaItem();
            //var resultado = RepComandaItem.Enviar(comanda_item, retorno);
            //banco.Fechar();

            //return resultado;

            return false;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(Comanda_Item comanda_Item)
        {
            RepComandaItem RepComandaItem = new RepComandaItem();
            return RepComandaItem.Delete(comanda_Item);
        }
    }
}