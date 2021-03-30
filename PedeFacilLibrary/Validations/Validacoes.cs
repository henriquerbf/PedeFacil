using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedeFacilLibrary.Validations
{
    public class Validacoes
    {
        public static IEnumerable<ValidationResult> Validar_Objeto(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        public string Validar(object obj)
        {
            var erros = Validar_Objeto(obj);
            string a = "";
            foreach (var error in erros)
            {
                a += "<br>" + error;
                break;
            }
            return a;
        }
    }
}