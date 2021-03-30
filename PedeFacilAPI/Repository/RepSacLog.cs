using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;

namespace PedeFacilAPI.Repository
{
    public class RepSacLog
    {
        public bool Enviar(SAC_Log sac_log)
        {
            var query = "insert into sac_log values (@Sac_Protocolo,'@Mensagem','@DataHora')";

            query = query.Replace("@Sac_Protocolo", sac_log.id_SAC_Protocolo.ToString())
                         .Replace("@Mensagem", sac_log.ds_Mensagem)
                         .Replace("@DataHora", sac_log.DataHora.ToString());

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
            var query = "select * from SAC_Log";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new SAC_Log
                    {
                        id_SAC_Log = Convert.ToInt32(reader["id_SAC_Log"]),
                        id_SAC_Protocolo = Convert.ToInt32(reader["id_SAC_Protocolo"]),
                        DataHora = Convert.ToDateTime(reader["Data_Hora"]),
                        ds_Mensagem = reader["ds_Mensagem"].ToString()
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