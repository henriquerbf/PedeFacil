using PedeFacilAPI.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Cardapio")]
    public class CardapioController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<object> Select()
        {
            RepCardapio rep = new RepCardapio();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Cardapio cardapio)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("cardapio", "id_Cardapio", cardapio.id_Cardapio);

            RepCardapio RepCardapio = new RepCardapio();
            var resultado = RepCardapio.Enviar(cardapio, retorno);
            banco.Fechar();

            return resultado;
        }
    }
}