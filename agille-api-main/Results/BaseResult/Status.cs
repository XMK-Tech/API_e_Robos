using System.Collections.Generic;
using System.Linq;

namespace Backend.Results.BaseResult
{
    public class Status
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool Flag { get; set; }

        public Status InstanceByStatusCode(string statuscode)
        {
            Code = statuscode;
            Message = MensagemByCode(statuscode);
            Flag = (statuscode == "200" || statuscode == "201" || statuscode == "202") ? true : false;

            return this;
        }

        public string MensagemByCode(string statuscode)
        {
            var MensageCodes = new Dictionary<string, string>();

            MensageCodes.Add("200",
              "Sucesso. Procedimento realizado com sucesso.");

            MensageCodes.Add("201",
              "Sucesso. Recurso criado com sucesso.");

            MensageCodes.Add("202",
              "Sucesso. Procedimento aceito e realizando o processamento.");

            //MensageCodes.Add("400",
            //  "Inválido. Ausência de campos obrigatórios na requisição. Sendo eles: campo1, campo2, campo3, …, campoN.");

            //MensageCodes.Add("400",
            //  "Inválido. A requisição apresenta erros de sintaxe. Confira se sua requisição parece com o exemplo abaixo: EXEMPLO");

            MensageCodes.Add("401",
              "Inválido. Você precisa estar autenticado para acessar este recurso.");

            MensageCodes.Add("403",
              "Inválido. Você não possui permissão para utilizar este recurso.");

            MensageCodes.Add("404",
              "Inválido. O recurso que está tentando acessar não existe.");

            MensageCodes.Add("405",
              "Inválido. O método que está tentando acessar não existe.");

            MensageCodes.Add("500",
              "Erro. O servidor encontrou um erro inesperado: Exceção.");

            MensageCodes.Add("503",
              "Erro. O servidor ou o recurso que está tentando utilizar encontra-se indisponível no momento. Tente mais tarde.");

            MensageCodes.Add("504",
              "Erro. O servidor não obteve resposta, atingindo o timeout.");

            return MensageCodes.Where(x => x.Key == statuscode).FirstOrDefault().Value;
        }


    }
}
//    "status": {
//        code: STATUS_CODE,
//        message: STATUS_MESSAGE,
//        flag: STATUS_FLAG
//    },