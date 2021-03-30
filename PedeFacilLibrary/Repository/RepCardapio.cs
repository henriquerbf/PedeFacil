using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepCardapio
    {
        public bool Enviar(Cardapio cardapio_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Cardapio Cardapio_antigo = new Cardapio();

                foreach (DataRow row in retorno.Rows)
                {
                    Cardapio_antigo.id_Entidade = Convert.ToInt32(row["id_Entidade"]);
                    Cardapio_antigo.id_Cardapio = Convert.ToInt32(row["id_Cardapio"]);
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

        public List<Cardapio> Select()
        {
            var query = "select * from cardapio";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Cardapio>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Cardapio
                    {
                        id_Cardapio = Convert.ToInt32(row["id_Cardapio"]),
                        id_Entidade = Convert.ToInt32(row["id_Entidade"])
                    });
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable Select_Cardapio(Entidade empresa)
        {
            var query = " SELECT T.Descricao as 'DS', CI.id_Cardapio_Item, CI.Nome, CI.Descricao, CI.Valor, CI.vl_Desconto, CI.ic_Destaque, CI.ic_Ativo from Cardapio_Item as CI " +
                        " JOIN Cardapio as C ON C.id_Cardapio = CI.id_Cardapio " +
                        " JOIN Tipo as T ON T.id_Tipo = CI.id_Tipo " +
                        " WHERE C.id_Entidade = " + empresa.id_Entidade;
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

        public DataTable Select_Cardapio_Cliente(Entidade empresa)
        {
            var query = " SELECT CI.id_Cardapio_Item, T.Descricao as 'Tipo', CI.Nome, CI.Descricao, CI.Valor, CI.vl_Desconto from Cardapio_Item as CI " +
                        " JOIN Cardapio as C ON C.id_Cardapio = CI.id_Cardapio " +
                        " JOIN Tipo as T ON T.id_Tipo = CI.id_Tipo" +
                        " WHERE C.id_Entidade = " + empresa.id_Entidade + " and ic_Ativo = 1";
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

        public DataTable Select_Cardapio_Destaque(Entidade empresa)
        {
            var query = " SELECT CI.id_Cardapio_Item, CI.Nome, CI.Descricao, CI.Valor from Cardapio_Item as CI " +
                        " JOIN Cardapio as C ON C.id_Cardapio = CI.id_Cardapio " +
                        " WHERE C.id_Entidade = " + empresa.id_Entidade + " and ic_Destaque = 1 and ic_Ativo = 1";
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

        public DataTable Select_Cardapio_Promocao(Entidade empresa)
        {
            var query = " SELECT CI.id_Cardapio_Item, CI.Nome, CI.Descricao, CI.Valor, CI.vl_Desconto from Cardapio_Item as CI " +
                        " JOIN Cardapio as C ON C.id_Cardapio = CI.id_Cardapio " +
                        " WHERE C.id_Entidade = " + empresa.id_Entidade + " and CI.ic_Ativo = 1 and CI.vl_Desconto > 0";
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
    }
}