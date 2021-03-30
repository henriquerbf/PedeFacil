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
    public class Relatorios
    {
        public DataTable Select_Produtos_Mais_Vendidos(Entidade empresa)
        {
            var query = " SELECT CI.Nome, CI.Valor, SUM(C.qtd_Cardapio_Item) as 'QTD' from Cardapio_Item as CI " +
                        " JOIN dbo.Comanda_Item as C ON C.id_Cardapio_Item = CI.id_Cardapio_Item " +
                        " JOIN dbo.Cardapio AS CD ON CD.id_Cardapio = CI.id_Cardapio" +
                        " JOIN dbo.Entidade AS E ON E.id_Entidade = CD.id_Entidade" +
                        " WHERE E.id_Entidade = " + empresa.id_Entidade +
                        " GROUP BY CI.Nome, CI.Valor ORDER BY QTD DESC";
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

        public DataTable Select_Lucro(string ano, Entidade entidade)
        {
            var query = " SELECT CASE MONTH(C.DataHora)" +
                        " WHEN 1 THEN 'Janeiro'" +
                        " WHEN 2 THEN 'Fevereiro'" +
                        " WHEN 3 THEN 'Março'" +
                        " WHEN 4 THEN 'Abril'" +
                        " WHEN 5 THEN 'Maio'" +
                        " WHEN 6 THEN 'Junho'" +
                        " WHEN 7 THEN 'Julho'" +
                        " WHEN 8 THEN 'Agosto'" +
                        " WHEN 9 THEN 'Setembro'" +
                        " WHEN 10 THEN 'Outubro'" +
                        " WHEN 11 THEN 'Novembro'" +
                        " WHEN 12 THEN 'Dezembro'" +
                        " END AS 'Mes', " +
                        " SUM(CI.vl_Cardapio_Item) as 'Total' FROM Comanda_Item AS CI" +
                        " JOIN Comanda AS C ON C.id_Comanda = CI.id_Comanda" +
                        " JOIN Mesa AS M ON M.id_Mesa = C.id_Mesa" +
                        " WHERE YEAR(C.DataHora) = '" + ano + "' and M.id_Entidade = " + entidade.id_Entidade +
                        " GROUP BY MONTH(C.DataHora)";

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

        public DataTable Select_Maior_Movimento(string mes, string ano, Entidade entidade)
        {
            var query = " SELECT (CASE DATEPART(w, CMD.datahora) " +
                        " WHEN 1 THEN 'Domingo' " +
                        " WHEN 2 THEN 'Segunda-feira' " +
                        " WHEN 3 THEN 'Terça-feira' " +
                        " WHEN 4 THEN 'Quarta-feira' " +
                        " WHEN 5 THEN 'Quinta-feira' " +
                        " WHEN 6 THEN 'Sexta-feira' " +
                        " WHEN 7 THEN 'Sábado' " +
                        " END) AS 'Dia', " +
                        " (SELECT COUNT(*) FROM comanda AS aux WHERE DATEPART(w, aux.DataHora) = DATEPART(w, CMD.datahora)) AS qtd " +
                        " FROM comanda AS CMD " +
                        " JOIN Mesa AS M ON M.id_Mesa = CMD.id_Mesa" +
                        " WHERE MONTH(CMD.datahora) = " + mes + " AND YEAR(CMD.datahora) = " + ano + " and M.id_Entidade = " + entidade.id_Entidade +
                        " GROUP BY DATEPART(w, CMD.datahora) ";

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
