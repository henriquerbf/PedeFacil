using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepMesa
    {
        public bool Enviar(Mesa mesa_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Mesa mesa_antigo = new Mesa();

                foreach (DataRow row in retorno.Rows)
                {
                    mesa_antigo.id_Mesa = Convert.ToInt32(row["id_Mesa"]);
                    mesa_antigo.ds_Mesa = row["ds_Mesa"].ToString();
                    mesa_antigo.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    mesa_antigo.ic_Status = Convert.ToByte(row["ic_Status"]);
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
            else
            {
                var query = "insert into Mesa values ('@Mesa',@Entidade, @Status)";

                query = query.Replace("@Mesa", mesa_novo.ds_Mesa)
                    .Replace("@Entidade", mesa_novo.id_Entidade.ToString())
                    .Replace("@Status", mesa_novo.ic_Status.ToString());

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

        public DataTable Select(Entidade Entidade)
        {
            var query = "select * from Mesa where id_Entidade = " + Entidade.id_Entidade;
            BancoTools banco = new BancoTools();

            try
            {
                var reader = banco.ExecuteReader(query);
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable Select_Cliente(Entidade Entidade)
        {
            var query = "select * from Mesa where id_Entidade = " + Entidade.id_Entidade + " and ic_Status = 1";
            BancoTools banco = new BancoTools();

            try
            {
                var reader = banco.ExecuteReader(query);
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Mesa Mesa)
        {
            var query = "update Mesa set ic_Status = " + Mesa.ic_Status + " where id_Mesa = " + Mesa.id_Mesa;
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