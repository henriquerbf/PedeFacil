using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PedeFacilAPI.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("Select")]
        public List<Usuario> Select()
        {
            RepUsuario rep = new RepUsuario();
            return rep.Select();
        }

        [HttpGet]
        [Route("Select_Email")]
        public List<Usuario> Select_Email(string email)
        {
            RepUsuario rep = new RepUsuario();
            return rep.Select_Email(email);
        }

        [HttpPut]
        [Route("Enviar")]
        public bool Enviar(Usuario usuario)
        {
            BancoTools banco = new BancoTools();
            var retorno = banco.checa_existe("Usuario", "id_Usuario", usuario.id_Usuario);

            RepUsuario RepUsuario = new RepUsuario();
            var resultado = RepUsuario.Enviar(usuario, retorno);
            banco.Fechar();

            return resultado;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(Usuario usuario)
        {
            RepUsuario RepUsuario = new RepUsuario();
            return RepUsuario.Delete(usuario);
        }
    }
}