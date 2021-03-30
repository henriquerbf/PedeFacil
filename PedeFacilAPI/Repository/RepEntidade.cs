using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepEntidade
    {
        public bool Enviar(Entidade entidade_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Entidade entidade_antigo = new Entidade();

                    while (retorno.Read())
                    {
                        entidade_antigo.id_Entidade = Convert.ToInt32(retorno["id_Entidade"]);
                        entidade_antigo.id_Tipo = Convert.ToInt32(retorno["id_Tipo"]);
                        entidade_antigo.Logradouro = retorno["Logradouro"].ToString();
                        entidade_antigo.Nome = retorno["Nome"].ToString();
                        entidade_antigo.Numero = retorno["Numero"].ToString();
                        entidade_antigo.Pais = retorno["Pais"].ToString();
                        entidade_antigo.RazaoSocial = retorno["RazaoSocial"].ToString();
                        entidade_antigo.Telefone = Convert.ToInt32(retorno["Telefone"]);
                        entidade_antigo.Estado = retorno["Estado"].ToString();
                        entidade_antigo.Email = retorno["Email"].ToString();
                        entidade_antigo.Complemento = retorno["Complemento"].ToString();
                        entidade_antigo.CNPJ_CPF = retorno["CNPJ_CPF"].ToString();
                        entidade_antigo.Cidade = retorno["Cidade"].ToString();
                        entidade_antigo.CEP = retorno["CEP"].ToString();
                        entidade_antigo.Bairro = retorno["Bairro"].ToString();
                    }

                    dynamic[,] resultado = banco.compara_objetos(entidade_novo, entidade_antigo);
                    string tabela = "Entidade";
                    if (resultado[0, 0] == true)
                    {
                        var query = banco.monta_update(resultado[0, 1], tabela, resultado[0, 2]);
                        banco.ExecuteNonQuery(query);
                    }
                    return false;
                }
            }
            else
            {
                var query = "insert into Entidade values (@Tipo,'@Nome','@RazaoSocial','@CNPJCPF',@Telefone," +
                                                      "'@Cidade','@Estado','@Pais','@Logradouro','@Bairro'," +
                                                      "'@Complemento','@Numero','@CEP','@Email')";

                query = query.Replace("@Tipo", entidade_novo.id_Tipo.ToString())
                             .Replace("@Nome", entidade_novo.Nome)
                             .Replace("@RazaoSocial", entidade_novo.RazaoSocial)
                             .Replace("@CNPJCPF", entidade_novo.CNPJ_CPF)
                             .Replace("@Telefone", entidade_novo.Telefone.ToString())
                             .Replace("@Cidade", entidade_novo.Cidade)
                             .Replace("@Estado", entidade_novo.Estado)
                             .Replace("@Pais", entidade_novo.Pais)
                             .Replace("@Logradouro", entidade_novo.Logradouro)
                             .Replace("@Bairro", entidade_novo.Bairro.ToString())
                             .Replace("@Complemento", entidade_novo.Complemento.ToString())
                             .Replace("@Numero", entidade_novo.Numero)
                             .Replace("@CEP", entidade_novo.CEP)
                             .Replace("@Email", entidade_novo.Email);

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
            var query = "select * from Entidade";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Entidade
                    {
                        Bairro = reader["Bairro"].ToString(),
                        CEP = reader["CEP"].ToString(),
                        Cidade = reader["Cidade"].ToString(),
                        CNPJ_CPF = reader["CNPJ_CPF"].ToString(),
                        Complemento = reader["Complemento"].ToString(),
                        Email = reader["Email"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        id_Entidade = Convert.ToInt32(reader["id_Entidade"]),
                        id_Tipo = Convert.ToInt32(reader["id_Tipo"]),
                        Telefone = Convert.ToInt32(reader["Telefone"]),
                        Logradouro = reader["Logradouro"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Numero = reader["Numero"].ToString(),
                        Pais = reader["Pais"].ToString(),
                        RazaoSocial = reader["Razao_Social"].ToString()
                    });
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
    }
}