using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace NewsApp.Services
{
    public interface INewsService
    {
        Task<NewsSourceList> GetSources();

        Task<ArticleList> GetArticles(string sourceId);
    }

    public class NewsService : INewsService
    {
        private const string SourcesUrl = "https://newsapi.org/v1/sources";
        private const string ArticlesUrl = "https://newsapi.org/v1/articles";
        private const string APIKEY = "9cf2cd7720304e66847b7c7cbe6f9a11";

        private HttpClient client;

        // Create Constructor + setup the HTTPClient inside of it
        public NewsService()
        {
            this.client = new HttpClient();
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-API-KEY", APIKEY);
            
        }
        
       public async Task<NewsSourceList> GetSources()
       {
            client.BaseAddress = new Uri(SourcesUrl); 

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                //Debug.WriteLine(response.Content);
                return await response.Content.ReadAsAsync<NewsSourceList>();

                //var jsonStr = await response.Content.ReadAsStringAsync();                
                //var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                //var manualDeserialisation = JsonConvert.DeserializeObject<NewsSourceList>(jsonStr);
                //return manualDeserialisation;
            }

            return null;
        }

        public async Task<ArticleList> GetArticles(string sourceId)
        {
            client.BaseAddress = new Uri(ArticlesUrl);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "?source=" + sourceId + "&apiKey=" + APIKEY);

            if (response.IsSuccessStatusCode)
            {
                var articles = await response.Content.ReadAsAsync<ArticleList>();

                //return await response.Content.ReadAsAsync<ArticleList>();
                return articles;
            }

            return null;
        }

    }
}
