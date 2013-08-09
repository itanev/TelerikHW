using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchNews
{
    class Program
    {
        static void Main()
        {
            string searchPhrase = "Michel";
            int count = 10;
            string baseUri = "http://api.feedzilla.com/v1/articles/search.json";
            string queryString = string.Format("?q={0}&count={1}", searchPhrase, count);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);

            var response = client.GetAsync(queryString).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            var collectionArticles = JsonConvert.DeserializeAnonymousType(json, new { Articles = new List<Article>()});

            foreach (var article in collectionArticles.Articles)
	        {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Title: {0}", article.Title);
                Console.WriteLine("URL: {0}", article.Url);
                Console.WriteLine(new string('-', 50));
	        } 
        }
    }
}
