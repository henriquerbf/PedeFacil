using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PedeFacilAPI.Repository
{
    public class RepCardapio
    {
        public bool Enviar(Cardapio cardapio_novo, SqlDataReader retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno != null)
            {
                if (true)
                {
                    Cardapio Cardapio_antigo = new Cardapio();

                    while (retorno.Read())
                    {
                        Cardapio_antigo.id_Entidade = Convert.ToInt32(retorno["id_Entidade"]);
                        Cardapio_antigo.id_Cardapio = Convert.ToInt32(retorno["id_Cardapio"]);
                    }

                    dynamic[,] resultado = banco.compara_objetos(cardapio_novo, Cardapio_antigo);
                    string tabela = "Cardapio";
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
                var query = "insert into Cardapio values (@Entidade)";

                query = query.Replace("@Entidade", cardapio_novo.id_Entidade.ToString());

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
            var query = "select * from cardapio";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<object>();
                var reader = banco.ExecuteReader(query);

                while (reader.Read())
                {
                    Lista.Add(new Cardapio
                    {
                        id_Cardapio = Convert.ToInt32(reader["id_Cardapio"]),
                        id_Entidade = Convert.ToInt32(reader["id_Entidade"])
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