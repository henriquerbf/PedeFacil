using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PedeFacilLibrary.Repository
{
    public class RepTipo
    {
        public bool Enviar(Tipo tipo_novo, DataTable retorno)
        {
            BancoTools banco = new BancoTools();

            if (retorno.Rows.Count > 0)
            {
                Tipo tipo_antigo = new Tipo();

                foreach (DataRow row in retorno.Rows)
                {
                    tipo_antigo.id_Tipo = Convert.ToInt32(row["id_Tipo"]);
                    tipo_antigo.Descricao = row["Descricao"].ToString();
                    tipo_antigo.ds_Grupo = row["ds_Grupo"].ToString();
                }

                dynamic[,] resultado = banco.compara_objetos(tipo_novo, tipo_antigo);
                string tabela = "Tipo";
                if (resultado[0, 0] == true)
                {
                    var query = banco.monta_update(resultado[0, 1], tabela, resultado[0, 2]);
                    banco.ExecuteNonQuery(query);
                }
                return false;
            }

            else
            {
                var query = "insert into Tipo values ('@Descricao','@Grupo')";

                query = query.Replace("@Descricao", tipo_novo.Descricao)
                                     .Replace("@Grupo", tipo_novo.ds_Grupo);

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

        public List<Tipo> SelectTipoCardapio()
        {
            var query = "select * from Tipo where ds_Grupo = 'Cardapio'";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Tipo>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Tipo
                    {
                        id_Tipo = Convert.ToInt32(row["id_Tipo"]),
                        Descricao = row["Descricao"].ToString(),
                        ds_Grupo = row["ds_Grupo"].ToString()
                    });
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Tipo> Select()
        {
            var query = "select * from Tipo";
            BancoTools banco = new BancoTools();

            try
            {
                var Lista = new List<Tipo>();
                var reader = banco.ExecuteReader(query);

                foreach (DataRow row in reader.Rows)
                {
                    Lista.Add(new Tipo
                    {
                        id_Tipo = Convert.ToInt32(row["id_Tipo"]),
                        Descricao = row["Descricao"].ToString(),
                        ds_Grupo = row["ds_Grupo"].ToString()
                    });
                }
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}