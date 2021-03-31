using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepMesa
    {
        public bool Enviar(Mesa mesa_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Mesa mesa_antigo = new Mesa();

                    while (retorno.Read())
                    {
                        mesa_antigo.id_Mesa = Convert.ToInt32(retorno["id_Mesa"]);
                        mesa_antigo.ds_Mesa = retorno["ds_Mesa"].ToString();
                        mesa_antigo.id_Entidade = Convert.ToInt32(retorno["id_Entidade"]);
                    }

                    dynamic[,] resultado = banco.compara_objetos(mesa_novo, mesa_antigo);
                    string tabela = "Mesa";
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
                var query = "insert into Mesa values (@Entidade,'@Mesa')";

                query = query.Replace("@Entidade", mesa_novo.id_Entidade.ToString())
                    .Replace("@Mesa", mesa_novo.ds_Mesa);

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
            var query = "select * from Mesa";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Mesa
                    {
                        id_Entidade = Convert.ToInt32(row["id_Entidade"]),
                        id_Mesa = Convert.ToInt32(row["id_Mesa"]),
                        ds_Mesa = row["ds_Mesa"].ToString()
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

        public bool Delete(Mesa Mesa)
        {
            var query = "delete from Mesa where id_Mesa = " + Mesa.id_Mesa;
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