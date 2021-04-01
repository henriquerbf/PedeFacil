using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Entidade")]
    public class EntidadeController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<Entidade> Select()
        {
            RepEntidade rep = new RepEntidade();
            return rep.Select();
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Entidade entidade)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("Entidade", "id_Entidade", entidade.id_Entidade);

            RepEntidade RepEntidade = new RepEntidade();
            var resultado = RepEntidade.Enviar(entidade, retorno);
            banco.Fechar();

            return resultado;
        }
    }
}