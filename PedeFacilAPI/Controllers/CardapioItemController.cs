using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Cardapio_Item")]
    public class CardapioItemController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<Cardapio_Item> Select_CardapioItem()
        {
            RepCardapioItem rep = new RepCardapioItem();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Cardapio_Item cardapio_item)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("cardapio_item", "id_Cardapio_Item", cardapio_item.id_Cardapio_Item);

            RepCardapioItem RepCardapioItem = new RepCardapioItem();
            var resultado = RepCardapioItem.Enviar(cardapio_item, retorno);
            banco.Fechar();

            return resultado;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete_CardapioItem(Cardapio_Item cardapio_Item)
        {
            RepCardapioItem RepCardapioItem = new RepCardapioItem();
            return RepCardapioItem.Delete(cardapio_Item);
        }
    }
}