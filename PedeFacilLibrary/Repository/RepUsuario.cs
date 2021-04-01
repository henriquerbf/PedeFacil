using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepUsuario
    {

        public List<Usuario> Select()
        {
            var query = "select Usuario.*, Entidade.* from Usuario join Entidade on Entidade.id_Entidade = Usuario.id_Entidade";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Usuario>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Usuario Usuario = new Usuario();
                    Usuario.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    Usuario.id_Usuario = Convert.ToInt32(row["id_Usuario"]);
                    Usuario.Login = row["Login"].ToString();
                    Usuario.Senha = row["Senha"].ToString();
                    Usuario.ic_Ativo = Convert.ToByte(row["ic_Ativo"]);
                    Usuario.Entidade.Nome = row["Nome"].ToString();
                    Usuario.Entidade.Email = row["Email"].ToString();
                    Usuario.Entidade.Bairro = row["Bairro"].ToString();
                    Lista.Add(Usuario);
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                banco.Fechar();
            }
        }
        public bool Enviar(Usuario usuario_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Usuario usuario_antigo = new Usuario();

                foreach (DataRow row in retorno.Rows)
                {
                    usuario_antigo.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    usuario_antigo.id_Usuario = Convert.ToInt32(row["id_Usuario"]);
                    usuario_antigo.Login = row["Login"].ToString();
                    usuario_antigo.Senha = row["Senha"].ToString();
                    usuario_antigo.id_Tipo = Convert.ToInt32(row["id_Tipo"]);
                }

                dynamic[,] resultado = banco.compara_objetos(usuario_novo, usuario_antigo);
                string tabela = "Usuario";
                if (resultado[0, 0] == true)
                {
                    var query = banco.monta_update(resultado[0, 1], tabela, resultado[0, 2]);
                    banco.ExecuteNonQuery(query);
                }
                return false;
            }
            else
            {
                var query = "insert into Usuario values ('@Login','@Senha',@Entidade,@Ativo,@Tipo)";

                query = query.Replace("@Login", usuario_novo.Login)
                             .Replace("@Senha", usuario_novo.Senha)
                             .Replace("@Entidade", usuario_novo.id_Entidade.ToString())
                             .Replace("@Ativo", usuario_novo.ic_Ativo.ToString())
                             .Replace("@Tipo", usuario_novo.id_Tipo.ToString());
                try
                {
                    banco.ExecuteNonQuery(query);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public DataTable Select_Usuario(Usuario usuario)
        {
            var query = "select usuario.*, entidade.nome from usuario join entidade on usuario.id_entidade = entidade.id_entidade where usuario.login = '" + usuario.Login + "'";
            BancoTools banco = new BancoTools();

            try
            {
                var reader = banco.ExecuteReader(query);
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable Select_Email(Entidade entidade)
        {
            var query = "select Usuario.id_Usuario, Entidade.Nome from Usuario join Entidade on Usuario.id_Entidade = Entidade.id_Entidade where Entidade.Email = '" + entidade.Email + "'";
            BancoTools banco = new BancoTools();

            try
            {
                var reader = banco.ExecuteReader(query);               
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Usuario> Select_Email(string Email)
        {
            var query = "select U.Login, U.Senha, E.Nome from usuario U join entidade E on U.id_entidade = E.id_entidade where E.email = '" + Email + "'";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Usuario>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Usuario Usuario = new Usuario();
                    Entidade Entidade = new Entidade();
                    Usuario.Login = row["Login"].ToString();
                    Usuario.Senha = row["Senha"].ToString();
                    Entidade.Nome = row["Nome"].ToString();
                    Usuario.Entidade = Entidade;
                    Lista.Add(Usuario);
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                banco.Fechar();
            }
        }

        public bool Delete(Usuario usuario)
        {
            var query = "update usuario set ic_Ativo = 0 where id_Usuario = " + usuario.id_Usuario;
            BancoTools banco = new BancoTools();

            try
            {
                banco.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Alterar_Senha(Usuario usuario)
        {
            var query = "update usuario set Senha = '" + usuario.Senha + "' where id_Usuario = " + usuario.id_Usuario;
            BancoTools banco = new BancoTools();

            try
            {
                banco.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}