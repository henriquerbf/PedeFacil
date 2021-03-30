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
    }
}