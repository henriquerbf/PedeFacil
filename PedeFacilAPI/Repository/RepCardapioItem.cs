using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepCardapioItem
    {
        public bool Enviar(Cardapio_Item cardapio_item_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Cardapio_Item Cardapio_Item_antigo = new Cardapio_Item();

                    while (retorno.Read())
                    {
                        Cardapio_Item_antigo.Descricao = retorno["Descricao"].ToString();
                        Cardapio_Item_antigo.ic_Ativo = Convert.ToByte(retorno["ic_Ativo"]);
                        Cardapio_Item_antigo.ic_Destaque = Convert.ToByte(retorno["ic_Destaque"]);
                        Cardapio_Item_antigo.id_Cardapio = Convert.ToInt32(retorno["id_Cardapio"]);
                        Cardapio_Item_antigo.id_Cardapio_Item = Convert.ToInt32(retorno["id_Cardapio_Item"]);
                        Cardapio_Item_antigo.id_Tipo = Convert.ToInt32(retorno["id_Tipo"]);
                        Cardapio_Item_antigo.Nome = retorno["Nome"].ToString();
                        Cardapio_Item_antigo.Valor = Convert.ToInt32(retorno["Valor"]);
                        Cardapio_Item_antigo.vl_Desconto = Convert.ToInt32(retorno["vl_Desconto"]);
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

        public List<object> Select()
        {
            var query = "select * from Cardapio_Item";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Cardapio_Item
                    {
                        Descricao = reader["Descricao"].ToString(),
                        ic_Destaque = Convert.ToByte(reader["ic_Destaque"]),
                        id_Cardapio_Item = Convert.ToInt32(reader["id_Cardapio_Item"]),
                        id_Tipo = Convert.ToInt32(reader["id_Tipo"]),
                        Nome = reader["Nome"].ToString(),
                        Valor = float.Parse(reader["Valor"].ToString()),
                        vl_Desconto = float.Parse(reader["vl_Desconto"].ToString()),
                        id_Cardapio = Convert.ToInt32(reader["id_Cardapio"]),
                        ic_Ativo = Convert.ToByte(reader["ic_Ativo"])
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

        public bool Delete(Cardapio_Item cardapio_item)
        {
            var query = "update Cardapio_Item set ic_Ativo = 0 where id_Cardapio_Item = " + cardapio_item.id_Cardapio_Item;
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