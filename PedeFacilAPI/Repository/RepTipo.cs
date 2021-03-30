using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepTipo
    {
        public bool Enviar(Tipo tipo_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Tipo tipo_antigo = new Tipo();

                    while (retorno.Read())
                    {
                        tipo_antigo.id_Tipo = Convert.ToInt32(retorno["id_Tipo"]);
                        tipo_antigo.Descricao = retorno["Descricao"].ToString();
                        tipo_antigo.ds_Grupo = retorno["ds_Grupo"].ToString();
                    }

                    dynamic[,] resultado = banco.compara_objetos(tipo_novo, tipo_antigo);
                    string tabela = "Tipo";
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
                var query = "insert into Tipo values ('@Descricao','@Grupo')";

                query = query.Replace("@Descricao", tipo_novo.Descricao)
                             .Replace("@Grupo", tipo_novo.ds_Grupo);

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
            var query = "select * from Tipo";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Tipo
                    {
                        id_Tipo = Convert.ToInt32(reader["id_Tipo"]),
                        Descricao = reader["Descricao"].ToString(),
                        ds_Grupo = reader["ds_Grupo"].ToString()
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