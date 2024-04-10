using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Newtonsoft.Json;

namespace AgilleApi.Domain.Services.Commom;
public class MiddlewareClient : IMiddlewareClient
{
    public string ApiKey { get; }
    public string ApiUrl { get; }

    public MiddlewareClient(string apiKey, string apiUrl)
    {
        this.ApiKey = apiKey;
        this.ApiUrl = apiUrl;
    }

    private HttpClient GetClient()
    {
        var httpClient = new HttpClient()
        {
            DefaultRequestHeaders = {
                { "ApiKey", this.ApiKey }
            },
            Timeout = TimeSpan.FromSeconds(4),
        };
        return httpClient;
    }

    public T GetParsedResponse<T>(string url)
    {
        var client = GetClient();
        return GetParsedResponse<T>(client, url);
    }
    private T GetParsedResponse<T>(HttpClient client, string url)
    {
        HttpResponseMessage response = GetResponse(client, url);
        var rawResult = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<T>(rawResult);
        return result;
    }

    private string UpdateParsedResponse(HttpClient client, string url, HttpContent body)
    {
        HttpResponseMessage response = PutResponse(client, body, url);
        var result = response.Content.ReadAsStringAsync().Result;
        return result;
    }

    private HttpStatusCode PostParsedResponse(HttpClient client, string url, HttpContent body)
    {
        HttpResponseMessage response = PostResponse(client, body, url);
        var result = response.StatusCode;
        return result;
    }

    private HttpResponseMessage GetResponse(HttpClient client, string url)
    {
        return client.GetAsync($"{this.ApiUrl}/{url}").Result;
    }

    private HttpResponseMessage PutResponse(HttpClient client, HttpContent body, string url)
    {
        return client.PutAsync($"{this.ApiUrl}/{url}", body).Result;
    }

    private HttpResponseMessage PostResponse(HttpClient client, HttpContent body, string url)
    {
        return client.PostAsync($"{this.ApiUrl}/{url}", body).Result;
    }

    public string GetConnectionStringFromMiddleware(string tenantId)
    {
        var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME");
        var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
        using (var httpClient = GetClient())
        {
            var parsedResult = GetParsedResponse<DatabaseConnectionString>(httpClient, $"entities/{tenantId}/database");
            //TODO: add support for SQL Server Authentication
            return $"Server={parsedResult.Content.data.Ip};Initial Catalog={parsedResult.Content.data.DatabaseName};Persist Security Info=False;User ID={(!string.IsNullOrEmpty(username) ? username : "developer")};Password={(!string.IsNullOrEmpty(password) ? password : "NpT7EDr7NfOK29f")};MultipleActiveResultSets=False;TrustServerCertificate=True;Connection Timeout=30;";
        }
    }

    //TODO: Use generics to avoid duplication

    class UserInfoData
    {
        public UserInfoContent Content { get; set; }
    }

    public class UserInfoContent
    {
        public List<UserInfoViewModel> data { get; set; }
    }
    class ConnectionData
    {
        public Connection data { get; set; }
    }
    class DatabaseConnectionString
    {
        public ConnectionData Content { get; set; }
    }

    class Connection
    {
        public string Ip { get; set; }
        public string DatabaseName { get; set; }
    }

    public List<UserInfoViewModel> GetUserInfos(List<Guid> list)
    {
        using (var client = GetClient())
        {
            var parsedResult = GetParsedResponse<UserInfoData>(client, $"user/user-info-by-ids?{string.Join("&", list.Select(x => $"Ids={x}"))}");
            return parsedResult?.Content?.data;
        }
    }

    public List<UserInfoViewModel> GetUserInfosByPermission(Guid entityId, string permission)
    {
        using (var client = GetClient())
        {
            var parsedResult = GetParsedResponse<UserInfoData>(client, $"user/user-info-permission?entityId={entityId}&permission={permission}");
            return parsedResult?.Content?.data;
        }
    }

    public HttpStatusCode PostSendEmailNotification(PostMiddlwareNotificationViewModel model)
    {
        var json = JsonConvert.SerializeObject(model);

        var parsedResult = Post(json, $"messages/api");
        return parsedResult;
    }

    public HttpStatusCode Post(string json, string url)
    {
        var body = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        using var client = GetClient();
        var parsedResult = PostParsedResponse(client, url, body);
        return parsedResult;
    }

    public MiddlewareUserIdViewModel PutUser(string json)
    {
        var body = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = GetClient();
        var response = UpdateParsedResponse(client, "user/api-upsert", body);

        var responseBody = JsonConvert.DeserializeObject<MiddlewareContent<MiddlewareUserIdViewModel>>(response);
        var data = responseBody?.Content?.Data ?? new();

        data.Messages = responseBody?.Messages;
        return data;
    }

    public MiddlewareUserIdViewModel InsertDefaultPermission(string json)
    {
        var body = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = GetClient();
        var response = UpdateParsedResponse(client, "user/Insert-DefaultPermission", body);

        var responseBody = JsonConvert.DeserializeObject<MiddlewareContent<MiddlewareUserIdViewModel>>(response);
        var data = responseBody?.Content?.Data ?? new();

        data.Messages = responseBody?.Messages;
        return data;
    }

    public void Update(Entities.Entities model, Guid id)
    {
        var content = new EntitiesContentDataResponse()
        {
            Id = id,
            Name = model.Name,
            Document = model.Document,
            Address = model.Address,
            EntityImage = model.EntityImage,
            Content = model.Content.ConvertToJson()
        };

        var body = new StringContent(content.ConvertToJson(), System.Text.Encoding.UTF8, "application/json");
        using (var client = GetClient())
        {
            var parsedResult = UpdateParsedResponse(client, $"entities/{id}/custom-data", body);
            return;
        }
    }

    public EntitiesContentDataResponse Get(Guid id)
    {
        using (var client = GetClient())
        {
            var parsedResult = GetParsedResponse<EntitiesContent>(client, $"entities/{id}/custom-data");
            return parsedResult?.Content?.Data;
        }
    }

    public class EntitiesContent
    {
        public EntitiesContentData Content { get; set; }
    }

    public class EntitiesContentData
    {
        public EntitiesContentDataResponse Data { get; set; }
    }

    public class EntitiesContentDataResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Content { get; set; }
        public string EntityImage { get; set; }
        public EntityAddress Address { get; set; }

        public string ConvertToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class MiddlewareContent<T>
    {
        public List<string> Messages { get; set; }
        public MiddlewareContentData<T> Content { get; set; }
    }

    public class MiddlewareContentData<T>
    {
        public T Data { get; set; }
    }
}
