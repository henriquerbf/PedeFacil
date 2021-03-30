using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepComanda
    {
        public bool Enviar(Comanda comanda_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Comanda Comanda_antigo = new Comanda();

                    while (retorno.Read())
                    {
                        Comanda_antigo.id_Mesa = Convert.ToInt32(retorno["id_Mesa"]);
                        Comanda_antigo.id_Comanda = Convert.ToInt32(retorno["id_Comanda"]);
                        Comanda_antigo.id_Entidade = Convert.ToInt32(retorno["id_Entidade"]);
                        Comanda_antigo.nm_Comanda = retorno["nm_Comanda"].ToString();
                    }

                    dynamic[,] resultado = banco.compara_objetos(comanda_novo, Comanda_antigo);
                    string tabela = "Comanda";
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
                var query = "insert into Comanda values (@Entidade,@Mesa,'@Localizacao')";

                query = query.Replace("@Entidade", comanda_novo.id_Entidade.ToString())
                             .Replace("@Mesa", comanda_novo.id_Mesa.ToString())
                             .Replace("@Comanda", comanda_novo.nm_Comanda);
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
            var query = "select * from Comanda";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Comanda
                    {
                        nm_Comanda = reader["nm_Comanda"].ToString(),
                        id_Comanda = Convert.ToInt32(reader["id_Comanda"]),
                        id_Entidade = Convert.ToInt32(reader["id_Entidade"]),
                        id_Mesa = Convert.ToInt32(reader["id_Mesa"])
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

        public bool Delete(Comanda comanda)
        {
            var query = "delete from Comanda where id_Comanda = " + comanda.id_Comanda;
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