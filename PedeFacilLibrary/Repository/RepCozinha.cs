using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedeFacilLibrary.Repository
{
    public class RepCozinha
    {
        public bool Enviar(Cozinha cozinha)
        {
            var query = "insert into Cozinha values (@Comanda,@Item,'@DataHora',@Status, '@Observacao')";

            query = query.Replace("@Comanda", cozinha.id_Comanda.ToString())
                         .Replace("@Item", cozinha.id_Comanda_Item.ToString())
                         .Replace("@DataHora", cozinha.DataHora.ToString("yyyy-MM-dd HH:mm:ss"))
                         .Replace("@Status", cozinha.ic_Status.ToString())
                         .Replace("@Observacao", cozinha.ds_Observacao);
                         
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


        public DataTable Select_Cozinha(Entidade entidade)
        {
            var query = "select C.id_Cozinha, C.id_Comanda, C.id_Comanda_Item, CM.nm_Comanda, C.ds_Observacao, M.ds_Mesa, CI.Nome, CMI.qtd_Cardapio_Item, C.ic_Status from Cozinha as C " +
                " join Comanda AS CM ON CM.id_Comanda = C.id_Comanda " +
                " join Comanda_Item as CMI on CMI.id_Comanda_Item = C.id_Comanda_Item " +
                " join Cardapio_Item as CI on CI.id_Cardapio_Item = CMI.id_Cardapio_Item " +
                " join Mesa as M on M.id_mesa = CM.id_mesa " +
                " where M.id_Entidade = " + entidade.id_Entidade + " and CM.ic_Status = 1 and C.ic_Status = 0";
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

        public bool Update(Cozinha cozinha)
        {
            var query = "update Cozinha set ic_Status = " + cozinha.ic_Status + " where id_Cozinha = " + cozinha.id_Comanda;
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

        public bool Delete(Cozinha cozinha)
        {
            var query = "delete from Cozinha where id_Cozinha = " + cozinha.id_Cozinha;
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
