using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Services
{
    public class ApiServices : IApiServices
    {
        private readonly string _baseUrl;
        public ApiServices(IConfiguration Configurations)
        {
            _baseUrl = Configurations.GetSection("ApiServer").Value;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseUrl}{uri}"),

                };
                string jsonResult = string.Empty;

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var json = JsonConvert.DeserializeObject<T>(jsonResult);
                        return json;
                    }

                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ApplicationException(jsonResult);
                    }

                    throw new ApplicationException("Error al consultar");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TOut> PostAsync<TOut, TIn>(TIn entity, string requestUri)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<TOut>(responseBody);
                        }
                        else
                        {
                            var responseBody = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                            var message = responseBody.Value<string>("message");
                            throw new Exception(message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TOut> PutAsync<TOut, TIn>(TIn entity, string requestUri)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<TOut>(responseBody);
                        }
                        else
                        {
                            var responseBody = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                            var message = responseBody.Value<string>("message");
                            throw new Exception(message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
