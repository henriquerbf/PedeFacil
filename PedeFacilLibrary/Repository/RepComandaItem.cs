using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepComandaItem
    {
        public bool Insert(Comanda_Item comanda_Item)
        {
            string valor;
            var query = "insert into Comanda_Item values (@Comanda,@CardapioItem,@Quantidade,@Valor)";
            query = query.Replace("@Comanda", comanda_Item.id_Comanda.ToString())
                         .Replace("@CardapioItem", comanda_Item.id_Cardapio_Item.ToString())
                         .Replace("@Quantidade", comanda_Item.qtd_Cardapio_Item.ToString());
            if (comanda_Item.vl_Cardapio_Item.ToString().Contains(","))
            {
                valor = comanda_Item.vl_Cardapio_Item.ToString().Replace(",", ".");
                query = query.Replace("@Valor", valor.ToString());
            }
            else
                query = query.Replace("@Valor", comanda_Item.vl_Cardapio_Item.ToString());
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

        public List<Comanda_Item> Select()
        {
            var query = "select * from Comanda_Item";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Comanda_Item>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Comanda_Item
                    {
                        id_Cardapio_Item = Convert.ToInt32(row["id_Cardapio_Item"]),
                        id_Comanda = Convert.ToInt32(row["id_Comanda"]),
                        id_Comanda_Item = Convert.ToInt32(row["id_Comanda_Item"]),
                        qtd_Cardapio_Item = Convert.ToInt32(row["qtd_Cardapio_Item"])
                    });
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update_Comanda_Cliente(Comanda_Item comanda_Item)
        {
            var query = "update Comanda_Item set qtd_Cardapio_Item = qtd_Cardapio_Item + " + comanda_Item.qtd_Cardapio_Item + " where id_Comanda_Item = " + comanda_Item.id_Comanda_Item;
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

        public bool Update_Comanda(Comanda_Item comanda_Item)
        {
            var query = "update Comanda_Item set qtd_Cardapio_Item = " + comanda_Item.qtd_Cardapio_Item + " where id_Comanda_Item = " + comanda_Item.id_Comanda_Item;
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