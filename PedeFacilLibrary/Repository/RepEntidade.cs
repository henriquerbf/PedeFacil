using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepEntidade
    {
        public bool Enviar(Entidade entidade_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Entidade entidade_antigo = new Entidade();

                foreach (DataRow row in retorno.Rows)
                {
                    entidade_antigo.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    entidade_antigo.id_Tipo = Convert.ToInt32(row["id_Tipo"]);
                    entidade_antigo.Logradouro = row["Logradouro"].ToString();
                    entidade_antigo.Nome = row["Nome"].ToString();
                    entidade_antigo.Numero = row["Numero"].ToString();
                    entidade_antigo.Pais = row["Pais"].ToString();
                    entidade_antigo.RazaoSocial = row["RazaoSocial"].ToString();
                    entidade_antigo.Telefone = Convert.ToInt64(row["Telefone"]);
                    entidade_antigo.Estado = row["Estado"].ToString();
                    entidade_antigo.Email = row["Email"].ToString();
                    entidade_antigo.Complemento = row["Complemento"].ToString();
                    entidade_antigo.CNPJ_CPF = row["CNPJ_CPF"].ToString();
                    entidade_antigo.Cidade = row["Cidade"].ToString();
                    entidade_antigo.CEP = row["CEP"].ToString();
                    entidade_antigo.Bairro = row["Bairro"].ToString();
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

        public bool updateCliente(Entidade entidade)
        {
            BancoTools banco = new BancoTools();
            var query = "update Entidade set Telefone = @Telefone, Nome = '@Nome', Email = '@Email' where id_Entidade = " + entidade.id_Entidade;

            query = query.Replace("@Email", entidade.Email)
                         .Replace("@Nome", entidade.Nome)
                         .Replace("@Telefone", entidade.Telefone.ToString());
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

        public List<Entidade> Select()
        {
            var query = "select * from Entidade where id_tipo = 2";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Entidade>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Entidade
                    {
                        Bairro = row["Bairro"].ToString(),
                        CEP = row["CEP"].ToString(),
                        Cidade = row["Cidade"].ToString(),
                        CNPJ_CPF = row["CNPJ_CPF"].ToString(),
                        Complemento = row["Complemento"].ToString(),
                        Email = row["Email"].ToString(),
                        Estado = row["Estado"].ToString(),
                        id_Entidade = Convert.ToInt32(row["id_Entidade"]),
                        id_Tipo = Convert.ToInt32(row["id_Tipo"]),
                        Telefone = Convert.ToInt64(row["Telefone"]),
                        Logradouro = row["Logradouro"].ToString(),
                        Nome = row["Nome"].ToString(),
                        Numero = row["Numero"].ToString(),
                        Pais = row["Pais"].ToString(),
                        RazaoSocial = row["RazaoSocial"].ToString()
                    });
                }
                return Lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Entidade Select_Entidade(Entidade entidade)
        {
            var query = "select * from Entidade where CNPJ_CPF = '" + entidade.CNPJ_CPF + "'";
            BancoTools banco = new BancoTools();

            try
            {
                var reader = banco.ExecuteReader(query);
                foreach (DataRow row in reader.Rows)
                {
                    entidade.Bairro = row["Bairro"].ToString();
                    entidade.CEP = row["CEP"].ToString();
                    entidade.Cidade = row["Cidade"].ToString();
                    entidade.CNPJ_CPF = row["CNPJ_CPF"].ToString();
                    entidade.Complemento = row["Complemento"].ToString();
                    entidade.Email = row["Email"].ToString();
                    entidade.Estado = row["Estado"].ToString();
                    entidade.id_Entidade = Convert.ToInt32(row["id_Entidade"].ToString());
                    entidade.id_Tipo = Convert.ToInt32(row["id_Tipo"].ToString());
                    entidade.Telefone = Convert.ToInt64(row["Telefone"].ToString());
                    entidade.Logradouro = row["Logradouro"].ToString();
                    entidade.Nome = row["Nome"].ToString();
                    entidade.Numero = row["Numero"].ToString();
                    entidade.Pais = row["Pais"].ToString();
                    entidade.RazaoSocial = row["RazaoSocial"].ToString();
                }
                return entidade;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}