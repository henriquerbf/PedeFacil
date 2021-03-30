using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Reflection;

namespace PedeFacilLibrary.Data_Services
{
    public class BancoTools
    {
        //public static string tempPath = @"App_Data\PedeFacil.mdf";
        //public static string caminho = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

        //public static string outputPath = caminho.Replace("bin", "")
        //                           .Replace("file:\\", "") + tempPath;

        //public static string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + outputPath + ";Integrated Security=True";

        public static string Conn = "workstation id=PedeFacil.mssql.somee.com;packet size=4096;user id=PedeFacil_SQLLogin_1;pwd=6i8yrnc9tp;data source=PedeFacil.mssql.somee.com;persist security info=False;initial catalog=PedeFacil";

        //public static string Conn = "workstation id=PedeFacilApp.mssql.somee.com;packet size=4096;user id=PedeFacilTCC_SQLLogin_1;pwd=klu9njhrtl;data source=PedeFacilApp.mssql.somee.com;persist security info=False;initial catalog=PedeFacilApp";
        
        public SqlConnection conexao = new SqlConnection(Conn);

        public SqlDataReader reader;

        public void Abrir()
        {
            this.conexao.Open();
        }

        public void Fechar()
        {
            this.conexao.Close();
            this.conexao.Dispose();
        }

        public void ExecuteNonQuery(string Query)
        {
            conexao.Open();
            SqlCommand comando = new SqlCommand(Query, conexao);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw null;
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
        }

        public DataTable ExecuteReader(string Query)
        {
            conexao.Open();
            DataTable tabela = new DataTable();
            SqlCommand comando = new SqlCommand(Query, conexao);
            try
            {
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    tabela.Load(reader);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
            return tabela;
        }

        public DataTable checa_existe(string Tabela, string CampoVerificador, dynamic Valor)
        {
            conexao.Open();
            DataTable tabela = new DataTable();
            var Query = "select * from @Tabela where @CampoVerificador = @Valor";
            Query = Query.Replace("@Tabela", Tabela)
                             .Replace("@CampoVerificador", CampoVerificador)
                             .Replace("@Valor", Valor.ToString());
            SqlCommand comando = new SqlCommand(Query, conexao);
            try
            {
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    tabela.Load(reader);
                }
            }
            catch
            {

            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
            return tabela;
        }

        public int retornaId(string tabela, string verificador, dynamic valor, string campo)
        {
            conexao.Open();
            var Query = "select id_@Tabela from @Tabela where @CampoVerificador = @Valor";
            Query = Query.Replace("@Tabela", tabela)
                             .Replace("@CampoVerificador", verificador)
                             .Replace("@Valor", valor.ToString());
            int id = 0;
            SqlCommand comando = new SqlCommand(Query, conexao);
            try
            {
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[campo].ToString());
                }
            }
            catch
            {

            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
            return id;
        }

        public string retornaCampo(string campo, string tabela, string join, string where)
        {
            conexao.Open();
            var Query = "select @Tabela.@Campo from @Tabela @Join where @Where";
            Query = Query.Replace("@Campo", campo)
                .Replace("@Tabela", tabela)
                .Replace("@Join", join)
                .Replace("@Where", where);

            string campoRetornado = "";
            SqlCommand comando = new SqlCommand(Query, conexao);
            try
            {
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    campoRetornado = reader[campo].ToString();
                }
            }
            catch
            {

            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
            return campoRetornado;
        }

        public dynamic compara_objetos(dynamic objeto1, dynamic objeto2)
        {
            var diferente = false;
            var objeto_novo = objeto1.GetType().GetProperties();
            var objeto_antigo = objeto2.GetType().GetProperties();

            int c = 0;
            foreach (var propriedade in objeto_novo)
            {
                c++;
            }

            dynamic[,] lista_novo = new dynamic[c, c - 1];
            dynamic[,] lista_antigo = new dynamic[c, c - 1];
            dynamic[,] lista_final = new dynamic[c, c - 1];

            c = 0;

            foreach (var propriedade in objeto_novo)
            {
                lista_novo[c, 0] = propriedade.PropertyType.Name;
                lista_novo[c, 1] = propriedade.Name;
                lista_novo[c, 2] = propriedade.GetValue(objeto1);
                c++;
            }

            c = 0;

            foreach (var propriedade in objeto_antigo)
            {
                lista_antigo[c, 0] = propriedade.PropertyType.Name;
                lista_antigo[c, 1] = propriedade.Name;
                lista_antigo[c, 2] = propriedade.GetValue(objeto2);
                c++;
            }

            for (int i = 0; i < c; i++)
            {
                if (lista_novo[i, 1] == lista_antigo[i, 1])
                {
                    if (lista_novo[i, 2] != lista_antigo[i, 2])
                    {
                        diferente = true;
                        lista_final[i, 0] = lista_novo[i, 0];
                        lista_final[i, 1] = lista_novo[i, 1];
                        lista_final[i, 2] = lista_novo[i, 2];
                    }
                    else
                    {
                        lista_final[i, 0] = lista_novo[i, 0];
                        lista_final[i, 1] = lista_novo[i, 1];
                        lista_final[i, 2] = lista_novo[i, 2];
                    }
                }
            }

            dynamic[,] resultado = new dynamic[1, 3];

            resultado[0, 0] = diferente;
            resultado[0, 1] = lista_final;
            resultado[0, 2] = c;

            if (diferente == true)
            {
                resultado[0, 0] = diferente;
                resultado[0, 1] = lista_final;
                resultado[0, 2] = c;
                return resultado;
            }
            else
            {
                resultado[0, 0] = diferente;
                resultado[0, 1] = lista_antigo;
                resultado[0, 2] = c;
                return resultado;
            }
        }

        public string monta_update(dynamic lista, string tabela, int qtd)
        {
            var query = "update " + tabela + " set ";

            for (int i = 1; i < qtd; i++)
            {
                if (lista[i, 0] != "String" && lista[i, 0] != "Int32" && lista[i, 0] != "Int64" && lista[i, 0] != "Single" && lista[i, 0] != "Byte")
                {

                }
                else
                {
                    if (lista[i, 0] == "String")
                    {
                        lista[i, 2] = "'" + lista[i, 2] + "'";
                    }
                    if (lista[i, 0] == "Single")
                    {
                        var a = lista[i, 2];

                        if (a.ToString().Contains(","))
                        {
                            a = a.ToString().Replace(",", ".");
                            lista[i, 2] = a;
                        }
                    }
                    query += lista[i, 1] + " = " + lista[i, 2] + ", ";
                }
            }

            query = query.Substring(0, query.Length - 2);
            query += " where " + lista[0, 1] + " = " + lista[0, 2] + "";
            return query;
        }

        public string nmComanda(string comanda)
        {
            string nmComanda = comanda;
            string Letra = nmComanda.Substring(0, 1);
            string Entidade = nmComanda.Substring(1, 1);
            string Comanda = nmComanda.Substring(2, 4);
            string novaComanda = "";
            string ComandaNova = "";
            char proximoCaracter = ' ';
            if (Convert.ToInt32(Comanda) == 9999)
            {
                proximoCaracter = Convert.ToChar(Convert.ToChar(Letra) + 1);
                novaComanda = "0001";
            }
            else
            {
                proximoCaracter = Convert.ToChar(Letra);
                novaComanda = (Convert.ToInt32(Comanda) + 1).ToString();
            }
            for (int i = 0; i < nmComanda.Length - 1; i++)
                ComandaNova = novaComanda.PadLeft(i, '0');

            comanda = proximoCaracter + Entidade + ComandaNova;

            return comanda;
        }
    }
}