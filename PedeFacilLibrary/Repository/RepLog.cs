using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Data;
using System.Collections.Generic;

namespace PedeFacilLibrary.Repository
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


                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Log
                    {
                        DataHora = Convert.ToDateTime(row["DataHora"]),
                        id_Log = Convert.ToInt32(row["id_Log"]),
                        Descricao = row["Descricao"].ToString()
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