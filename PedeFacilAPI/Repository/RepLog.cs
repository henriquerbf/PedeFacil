using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;

namespace PedeFacilAPI.Repository
{
    public class RepLog
    {
        public bool Enviar(Log log)
        {
            var query = "insert into Log values ('@DataHora','@Descricao')";

            query = query.Replace("@DataHora", log.DataHora.ToString())
                         .Replace("@Descricao", log.Descricao);

            try
            {
                BancoTools banco = new BancoTools();
                banco.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<object> Select()
        {
            var query = "select * from Log";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Log
                    {
                        DataHora = Convert.ToDateTime(reader["DataHora"]),
                        id_Log = Convert.ToInt32(reader["id_Log"]),
                        Descricao = reader["Descricao"].ToString()
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