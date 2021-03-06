using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace PedeFacilLibrary.Repository
{
    public class RepSacLog
    {
        public bool Enviar(SAC_Log sac_log)
        {
            var query = "insert into sac_log values ('@Mensagem', '@DataHora', @Entidade, '@Assunto')";

            query = query.Replace("@Mensagem", sac_log.ds_Mensagem)
                         .Replace("@DataHora", sac_log.DataHora.ToString("yyyy-MM-dd HH:mm:ss"))
                         .Replace("@Entidade", sac_log.id_Entidade.ToString())
                         .Replace("@Assunto", sac_log.ds_Assunto);

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
        public List<SAC_Log> Select()
        {
            var query = "select * from SAC_Log";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<SAC_Log>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new SAC_Log
                    {
                        id_SAC_Log = Convert.ToInt32(row["id_SAC_Log"]),
                        id_SAC_Protocolo = Convert.ToInt32(row["id_SAC_Protocolo"]),
                        DataHora = Convert.ToDateTime(row["Data_Hora"]),
                        ds_Mensagem = row["ds_Mensagem"].ToString()
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