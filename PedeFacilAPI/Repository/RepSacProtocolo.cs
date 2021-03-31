using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Data;
using System.Collections.Generic;

namespace PedeFacilAPI.Repository
{
    public class RepSacProtocolo
    {
        public bool Enviar(SAC_Protocolo sac_protocolo)
        {
            var query = "insert into SAC_Protocolo values ('@DataAbertura',@Entidade,@Tipo)";

            query = query.Replace("@DataAbertura", sac_protocolo.dt_Abertura_Protocolo.ToString())
                         .Replace("@Entidade", sac_protocolo.id_Entidade.ToString())
                         .Replace("@Tipo", sac_protocolo.id_Tipo.ToString());

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
            var query = "select * from SAC_Protocolo";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new SAC_Protocolo
                    {
                        id_Entidade = Convert.ToInt32(row["id_Entidade"]),
                        id_SAC_Protocolo = Convert.ToInt32(row["id_SAC_Protocolo"]),
                        id_Tipo = Convert.ToInt32(row["id_Tipo"]),
                        dt_Abertura_Protocolo = Convert.ToDateTime(row["dt_Abertura_Protocolo"])
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