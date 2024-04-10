using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.API.ControllersResult.Base
{
    public class Result<T> where T : class
    {
        public Result(int statusCode)
        {
            setMessages(statusCode);
            status.setStatus(statusCode);

        }
        public Result(int statusCode, T contentData)
        {
            setMessages(statusCode);
            status.setStatus(statusCode);
            content = new Content<T>(contentData);

        }
        public Result(int statusCode, T contentData, Metadata metadata)
        {
            setMessages(statusCode);
            status.setStatus(statusCode);
            content = new Content<T>(contentData);
            content.metadata = metadata;
        }
        public Result(int statusCode, Exception exception)
        {
            setExceptionErrorMessages(exception);
            setMessages(statusCode);
            status.setStatus(statusCode);
        }
        public Result(int statusCode, List<string> errors)
        {
            message = "Falha ao realizar o procedimento";
            messages = errors;
            setMessages(statusCode);
            status.setStatus(statusCode);
        }

        public List<string> messages { get; private set; } = new List<string>();
        public DateTime requestTime { get; private set; } = DateTime.Now;
        public StatusResponse status { get; private set; } = new StatusResponse();
        public Content<T> content { get; private set; }
        public string message { get; private set; }

        private void setMessages(int statusCode)
        {
            Dictionary<int, string> MensageCodes = new Dictionary<int, string>();

            MensageCodes.Add(200,
              "Sucesso. Procedimento realizado com sucesso.");

            MensageCodes.Add(201,
              "Sucesso. Recurso criado com sucesso.");

            MensageCodes.Add(202,
              "Sucesso. Procedimento aceito e realizando o processamento.");

            MensageCodes.Add(400,
              "Inválido. Ausência de campos obrigatórios na requisição. Sendo eles: campo1, campo2, campo3, …, campoN.");

            MensageCodes.Add(401,
              "Inválido. Você precisa estar autenticado para acessar este recurso.");

            MensageCodes.Add(403,
              "Inválido. Você não possui permissão para utilizar este recurso.");

            MensageCodes.Add(404,
              "Inválido. O recurso que está tentando acessar não existe.");

            MensageCodes.Add(405,
              "Inválido. O método que está tentando acessar não existe.");

            MensageCodes.Add(500,
              "Erro. O servidor encontrou um erro inesperado: Exceção.");

            MensageCodes.Add(503,
              "Erro. O servidor ou o recurso que está tentando utilizar encontra-se indisponível no momento. Tente mais tarde.");

            MensageCodes.Add(504,
              "Erro. O servidor não obteve resposta, atingindo o timeout.");

            messages.Add(MensageCodes.Where(x => x.Key == statusCode).FirstOrDefault().Value);

            if (String.IsNullOrEmpty(message))
                message = MensageCodes.Where(x => x.Key == statusCode).FirstOrDefault().Value;
            else
                message += ", " + MensageCodes.Where(x => x.Key == statusCode).FirstOrDefault().Value;
        }
        private void setExceptionErrorMessages(Exception exception)
        {
            messages.Add(message);

            if (String.IsNullOrEmpty(message))
                message = exception.Message;
            else
                message += ", " + exception.Message;

            if (exception.InnerException != null)
            {
                if (String.IsNullOrEmpty(message))
                    message = exception.InnerException.Message;
                else
                    message += ", " + exception.InnerException.Message;

                messages.Add(exception.InnerException.Message);
            }

        }
        private void setErrors(List<string> errors)
        {
            messages = errors;

            string _message = "";

            foreach (string erro in errors)
            {
                if (String.IsNullOrEmpty(message))
                    _message = erro;
                else
                    _message += ", " + erro;
            }

            if (String.IsNullOrEmpty(message))
                message = _message;
            else
                message += ", " + _message;
        }
    }
}
