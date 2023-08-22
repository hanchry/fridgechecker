


using System.Text;
using Newtonsoft.Json;

namespace fridgechecker.Utilities;

public  interface IApiClientProxy
{
    Task<T> GetEntityAsync<T>(string url);
    Task<T> PostEntityAsync<T>(string url, T entity);
    Task<T> PutEntityAsync<T>(string url, T entity, string token);
    Task<T> DeleteEntityAsync<T>(string url, string token);
}
public class ApiClientProxy:IApiClientProxy
{
    private readonly IConfiguration _config;
    
    
    private readonly Uri apiUri;
    private HttpClient client = new HttpClient();
    
    public ApiClientProxy(IConfiguration config)
    {
        _config = config;
        apiUri = new Uri(_config["ApiUrl"]);
        
        client.BaseAddress = apiUri;
    }
    public async Task<T> GetEntityAsync<T>(string url)
    {
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            return default(T);
        }
    }

    public Task<T> PostEntityAsync<T>(string url, T entity)
    {
        var response = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")).Result;
        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.FromResult(JsonConvert.DeserializeObject<T>(content));
        }
        else
        {
            return Task.FromResult(default(T));
        }
    }

    public Task<T> PutEntityAsync<T>(string url, T entity, string token)
    {
        var response = client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")).Result;
        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.FromResult(JsonConvert.DeserializeObject<T>(content));
        }
        else
        {
            return Task.FromResult(default(T));
        }
    }

    public Task<T?> DeleteEntityAsync<T>(string url, string token)
    {
        var response = client.DeleteAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.FromResult(JsonConvert.DeserializeObject<T>(content));
        }
        else
        {
            return Task.FromResult(default(T));
        }
    }
}