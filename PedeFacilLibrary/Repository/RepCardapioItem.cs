using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepCardapioItem
    {
        public bool Enviar(Cardapio_Item cardapio_item_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Cardapio_Item Cardapio_Item_antigo = new Cardapio_Item();

                foreach (DataRow row in retorno.Rows)
                {
                    Cardapio_Item_antigo.Descricao = row["Descricao"].ToString();
                    Cardapio_Item_antigo.ic_Ativo = Convert.ToByte(row["ic_Ativo"]);
                    Cardapio_Item_antigo.ic_Destaque = Convert.ToByte(row["ic_Destaque"]);
                    Cardapio_Item_antigo.id_Cardapio = Convert.ToInt32(row["id_Cardapio"]);
                    Cardapio_Item_antigo.id_Cardapio_Item = Convert.ToInt32(row["id_Cardapio_Item"]);
                    Cardapio_Item_antigo.id_Tipo = Convert.ToInt32(row["id_Tipo"]);
                    Cardapio_Item_antigo.Nome = row["Nome"].ToString();
                    Cardapio_Item_antigo.Valor = float.Parse(row["Valor"].ToString());
                    Cardapio_Item_antigo.vl_Desconto = Convert.ToInt32(row["vl_Desconto"]);
                }

                dynamic[,] resultado = banco.compara_objetos(cardapio_item_novo, Cardapio_Item_antigo);
                string tabela = "Cardapio_Item";
                if (resultado[0, 0] == true)
                {
                    var query = banco.monta_update(resultado[0, 1], tabela, resultado[0, 2]);
                    banco.ExecuteNonQuery(query);
                }
                return false;
            }
            else
            {
                var query = "insert into Cardapio_Item values (@Tipo,'@Nome',@Valor,'@Descricao',@Desconto,@Destaque,@Cardapio,@Ativo)";

                query = query.Replace("@Tipo", cardapio_item_novo.id_Tipo.ToString())
                             .Replace("@Nome", cardapio_item_novo.Nome)
                             .Replace("@Valor", cardapio_item_novo.Valor.ToString().Replace(",", "."))
                             .Replace("@Descricao", cardapio_item_novo.Descricao)
                             .Replace("@Desconto", cardapio_item_novo.vl_Desconto.ToString().Replace(",", "."))
                             .Replace("@Destaque", cardapio_item_novo.ic_Destaque.ToString())
                             .Replace("@Cardapio", cardapio_item_novo.id_Cardapio.ToString())
                             .Replace("@Ativo", cardapio_item_novo.ic_Ativo.ToString());
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

        public List<Cardapio_Item> Select()
        {
            var query = "select * from Cardapio_Item";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Cardapio_Item>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Cardapio_Item
                    {
                        Descricao = row["Descricao"].ToString(),
                        ic_Destaque = Convert.ToByte(row["ic_Destaque"]),
                        id_Cardapio_Item = Convert.ToInt32(row["id_Cardapio_Item"]),
                        id_Tipo = Convert.ToInt32(row["id_Tipo"]),
                        Nome = row["Nome"].ToString(),
                        Valor = float.Parse(row["Valor"].ToString()),
                        vl_Desconto = float.Parse(row["vl_Desconto"].ToString()),
                        id_Cardapio = Convert.ToInt32(row["id_Cardapio"]),
                        ic_Ativo = Convert.ToByte(row["ic_Ativo"])
                    });
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable SelectHistoricoPedidos(Entidade Entidade)
        {
            var query = "select I.id_Cardapio_Item, I.Nome, I.Valor, CI.qtd_Cardapio_Item " +
                " from Cardapio_Item as I " +
                " left join Comanda_Item as CI on CI.id_Cardapio_Item = I.id_Cardapio_Item " +
                " left join mesa as M on M.id_mesa = C.id_mesa " +
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

        public bool Delete(Cardapio_Item cardapio_item)
        {
            var query = "update Cardapio_Item set ic_Ativo = " + cardapio_item.ic_Ativo + " where id_Cardapio_Item = " + cardapio_item.id_Cardapio_Item;
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