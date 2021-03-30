using PedeFacilLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedeFacilLibrary.Data_Services
{
    public class EnderecoTools
    {
        public object WebCEP(Entidade entidade)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + entidade.CEP.Replace("-", "").Trim() + "&formato=xml");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    entidade.Estado = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                    entidade.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                    entidade.Bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                    entidade.Logradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                }
            }
            return entidade;
        }
    }
}
