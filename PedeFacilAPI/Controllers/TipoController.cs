using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Tipo")]
    public class TipoController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<Tipo> Select()
        {
            RepTipo rep = new RepTipo();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Tipo tipo)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("Tipo", "id_Tipo", tipo.id_Tipo);

            RepTipo RepTipo = new RepTipo();
            var resultado = RepTipo.Enviar(tipo, retorno);
            banco.Fechar();

            return resultado;
        }
    }
}