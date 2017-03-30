using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public interface INewsService
    {
        Task<List<NewsSource>> GetSources();
    }

    public class NewsService/* : INewsService*/
    {
        // Create Constructor + setup the HTTPClient inside of it

        /*
        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }      
        */

        
        //public async Task<List<NewsSource>> INewsService.GetSources()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
