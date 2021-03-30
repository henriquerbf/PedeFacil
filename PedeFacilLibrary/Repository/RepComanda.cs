using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepComanda
    {
        public bool Enviar(Comanda comanda_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Comanda Comanda_antigo = new Comanda();

                foreach (DataRow row in retorno.Rows)
                {
                    Comanda_antigo.id_Mesa = Convert.ToInt32(row["id_Mesa"]);
                    Comanda_antigo.id_Comanda = Convert.ToInt32(row["id_Comanda"]);
                    Comanda_antigo.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    Comanda_antigo.nm_Comanda = row["nm_Comanda"].ToString();
                    Comanda_antigo.DataHora = Convert.ToDateTime(row["DataHora"]);
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
            else
            {
                var query = "insert into Comanda values (@Entidade, @Mesa, '@NmComanda', @Status, '@DataHora')";

                query = query.Replace("@Entidade", comanda_novo.id_Entidade.ToString())
                             .Replace("@Mesa", comanda_novo.id_Mesa.ToString())
                             .Replace("@NmComanda", comanda_novo.nm_Comanda)
                             .Replace("@Status", comanda_novo.ic_Status.ToString())
                             .Replace("@DataHora", comanda_novo.DataHora.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public DataTable Select_Entidade(Entidade Entidade)
        {
            var query = "select C.id_Comanda, C.nm_Comanda, E.Nome, M.ds_Mesa, Convert(varchar, C.DataHora, 103) as 'DataHora', C.ic_Status from Comanda as C " +
                "  join Mesa as M on M.id_mesa = C.id_mesa " +
                "  join Entidade as E on E.id_Entidade = C.id_Entidade " +
                " where M.id_Entidade = " + Entidade.id_Entidade;
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

        public DataTable Select_Comanda_Entidade(Entidade Entidade)
        {
            var query = "select C.id_Comanda, C.nm_Comanda, E.Nome, M.ds_Mesa, Convert(varchar, C.DataHora, 103) as 'DataHora', C.ic_Status from Comanda as C " +
                "  join Mesa as M on M.id_mesa = C.id_mesa " +
                "  join Entidade as E on E.id_Entidade = C.id_Entidade " +
                "  where M.id_Entidade = " + Entidade.id_Entidade + " and C.ic_Status = 1";
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

        public DataTable Select_Cliente(Entidade cliente, Entidade estabelecimento)
        {
            var query = " select C.id_Comanda, E.Nome, C.nm_Comanda, Convert(varchar, C.DataHora, 103) as 'DataHora', C.ic_Status from Comanda as C " +
                        " join Mesa as M on M.id_mesa = C.id_mesa " +
                        " join Entidade as E on E.id_Entidade = C.id_Entidade" +
                        " where C.id_Entidade = " + cliente.id_Entidade + " and M.id_Entidade = " + estabelecimento.id_Entidade;
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

        public DataTable Select_Comanda(Comanda comanda)
        {
            var query = " select CI.id_Comanda_Item, CDI.id_Cardapio_Item, C.id_Comanda, CDI.Nome, CI.vl_Cardapio_Item, CI.qtd_Cardapio_Item FROM Comanda as C " +
                        " JOIN Comanda_Item AS CI ON CI.id_Comanda = C.id_Comanda " +
                        " JOIN Cardapio_Item AS CDI ON CDI.id_Cardapio_Item = CI.id_Cardapio_Item " +
                        " where C.id_Comanda = " + comanda.id_Comanda;
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

        public DataTable Select_Comanda_Cliente(Comanda comanda)
        {
            var query = " select CI.id_Comanda_Item, CDI.id_Cardapio_Item, C.id_Comanda, C.nm_Comanda, CDI.Nome, CI.vl_Cardapio_Item, CI.qtd_Cardapio_Item FROM Comanda as C " +
                        " JOIN Comanda_Item AS CI ON CI.id_Comanda = C.id_Comanda " +
                        " JOIN Cardapio_Item AS CDI ON CDI.id_Cardapio_Item = CI.id_Cardapio_Item " +
                        " where C.id_Comanda = " + comanda.id_Comanda;
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

        public string Verificar_Comanda(string id_Entidade)
        {
            string comanda = "";
            var query = " select TOP 1 C.nm_Comanda from Comanda as C " +
                        " join Mesa as M on M.id_Mesa = C.id_Mesa " +
                        " where M.id_Entidade = " + id_Entidade + " order by nm_Comanda desc ";
            BancoTools banco = new BancoTools();
            try
            {
                var reader = banco.ExecuteReader(query);
                comanda = reader.Rows[0]["nm_Comanda"].ToString();
            }
            catch
            {

            }
            return comanda;
        }

        public bool Update(Comanda comanda)
        {
            var query = "update Comanda set ic_Status = " + comanda.ic_Status + " where id_Comanda = " + comanda.id_Comanda;
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