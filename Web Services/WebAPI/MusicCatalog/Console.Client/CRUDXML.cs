using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace ConsoleClient
{
    public class CRUDXML<T>
    {
        private string prefix;
        private HttpClient client;

        public CRUDXML(HttpClient client, string prefix)
        {
            this.prefix = prefix;
            this.client = client;
        }

        public void Update(int id, T newValue)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            MediaTypeFormatter xmlFormatter = new XmlMediaTypeFormatter();
            HttpContent content = new ObjectContent<T>(newValue, xmlFormatter);

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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            MediaTypeFormatter xmlFormatter = new XmlMediaTypeFormatter();
            HttpContent content = new ObjectContent<T>(newValue, xmlFormatter);

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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
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

        public void GetById(int id)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response = client.GetAsync("api/" + this.prefix + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<XElement>().Result;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetAll()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response = client.GetAsync("api/" + prefix).Result;
            if (response.IsSuccessStatusCode)
            {
                var values = response.Content.ReadAsAsync<XElement>().Result;
                Console.WriteLine(values);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
