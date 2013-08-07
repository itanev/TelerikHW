using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class CRUD<T>
    {
        private string prefix;
        private HttpClient client;

        public CRUD(HttpClient client, string prefix)
        {
            this.prefix = prefix;
            this.client = client;
        }

        public void Update(int id, T newValue)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent content = new ObjectContent<T>(newValue, jsonFormatter);

            var response = client.PutAsync("api/" + this.prefix + "/" + id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void Post(T newValue)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent content = new ObjectContent<T>(newValue, jsonFormatter);

            var response = client.PostAsync("api/" + this.prefix, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void Delete(int id)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, "api/" + this.prefix + "/" + id);

            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetById(int id, Action<T> Print)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/" + this.prefix + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<T>().Result;
                Print(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetAll(Action<T> Print)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/" + prefix).Result;
            if (response.IsSuccessStatusCode)
            {
                var values = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                foreach (var value in values)
                {
                    Print(value);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
