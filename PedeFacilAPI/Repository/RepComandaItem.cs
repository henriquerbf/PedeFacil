using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepComandaItem
    {
        public bool Enviar(Comanda_Item comanda_item_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Comanda_Item Comanda_Item_antigo = new Comanda_Item();

                    while (retorno.Read())
                    {
                        Comanda_Item_antigo.id_Comanda = Convert.ToInt32(retorno["id_Comanda"]);
                        Comanda_Item_antigo.id_Comanda_Item = Convert.ToInt32(retorno["id_Comanda_Item"]);
                        Comanda_Item_antigo.id_Cardapio_Item = Convert.ToInt32(retorno["id_Cardapio_Item"]);
                        Comanda_Item_antigo.qtd_Comanda_Item = Convert.ToInt32(retorno["qtd_Comanda_Item"]);
                    }

                    dynamic[,] resultado = banco.compara_objetos(comanda_item_novo, Comanda_Item_antigo);
                    string tabela = "Comanda_Item";
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
                var query = "insert into Comanda_Item values (@Comanda,@CardapioItem,@Quantidade)";

                query = query.Replace("@Comanda", comanda_item_novo.id_Comanda.ToString())
                             .Replace("@CardapioItem", comanda_item_novo.id_Cardapio_Item.ToString())
                             .Replace("@Quantidade", comanda_item_novo.qtd_Comanda_Item.ToString());

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
            var query = "select * from Comanda_Item";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Comanda_Item
                    {
                        id_Cardapio_Item = Convert.ToInt32(reader["id_Cardapio_Item"]),
                        id_Comanda = Convert.ToInt32(reader["id_Comanda"]),
                        id_Comanda_Item = Convert.ToInt32(reader["id_Comanda_Item"]),
                        qtd_Comanda_Item = Convert.ToInt32(reader["qtd_Cardapio_Item"])
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

        public bool Delete(Comanda_Item comanda_item)
        {
            var query = "delete from Comanda_Item where id_Comanda_Item = " + comanda_item.id_Comanda_Item;
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