using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepUsuario
    {
        public bool Enviar(Usuario usuario_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (retorno.HasRows)
                {
                    Usuario usuario_antigo = new Usuario();

                    while (retorno.Read())
                    {
                        usuario_antigo.id_Entidade = Convert.ToInt32(retorno["id_Entidade"]);
                        usuario_antigo.id_Usuario = Convert.ToInt32(retorno["id_Usuario"]);
                        usuario_antigo.Login = retorno["Login"].ToString();
                        usuario_antigo.Senha = retorno["Senha"].ToString();
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
                    return false;
                }
            }
            else
            {
                var query = "insert into Usuario values ('@Login','@Senha',@Entidade)";

                query = query.Replace("@Login", usuario_novo.Login)
                             .Replace("@Senha", usuario_novo.Senha)
                             .Replace("@Entidade", usuario_novo.id_Entidade.ToString());

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

        public List<object> Select()
        {
            var query = "select Usuario.*, Entidade.* from Usuario join Entidade on Entidade.id_Entidade = Usuario.id_Entidade";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Usuario Usuario = new Usuario();
                    Usuario.id_Entidade = Convert.ToInt32(reader["id_Entidade"]);
                    Usuario.id_Usuario = Convert.ToInt32(reader["id_Usuario"]);
                    Usuario.Login = reader["Login"].ToString();
                    Usuario.Senha = reader["Senha"].ToString();
                    Usuario.ic_Ativo = Convert.ToByte(reader["ic_Ativo"]);
                    Usuario.Entidade.Nome = reader["Nome"].ToString();
                    Usuario.Entidade.Email = reader["Email"].ToString();
                    Usuario.Entidade.Bairro = reader["Bairro"].ToString();
                    Lista.Add(Usuario);
                }
                reader.Close();
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

        public List<Usuario> Select_Email(string Email)
        {
            var query = "select U.Login, U.Senha, E.Nome from usuario U join entidade E on U.id_entidade = E.id_entidade where E.email = '" + Email + "'";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Usuario>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Usuario Usuario = new Usuario();
                    Entidade Entidade = new Entidade();
                    Usuario.Login = reader["Login"].ToString();
                    Usuario.Senha = reader["Senha"].ToString();
                    Entidade.Nome = reader["Nome"].ToString();
                    Usuario.Entidade = Entidade;
                    Lista.Add(Usuario);
                }
                reader.Close();
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
    }
}