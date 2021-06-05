using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace Repositorio
{
    public static class API <Model>
    {
        static String host = "http://apiprojetotoledo1.herokuapp.com/view/";
        static HttpClient client = new HttpClient();

        public static Model get(string path)
        {
            Func<string, Task<Model>> func = async (_path) =>
            {
                Model model = default;
                HttpResponseMessage response = await client.GetAsync(host + _path);
                if (response.IsSuccessStatusCode)
                {
                    HttpContent content = response.Content;
                    model = await content.ReadAsAsync<Model>();
                }
                return model;
            };

            return func(path).Result;
        }

        public async static void post(string path, Model model)
        {
            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(model);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(host + path, content);
            }
        }

        public static Model post(string path, int codigo)
        {
            Func<string, int, Task<List<Model>>> func = async (_path, _codigo) =>
            {
                using (var client = new HttpClient())
                {
                    List<Model> model = default;
                    object obj = new
                    {
                        cod_empresa = codigo
                    };

                    var serializedProduto = JsonConvert.SerializeObject(obj);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(host + path, content).ConfigureAwait(false);

                    if (result.IsSuccessStatusCode)
                    {
                        HttpContent content_response = result.Content;
                        model = await content_response.ReadAsAsync<List<Model>>();
                    }
                    return model;
                }
            };

            return func(path, codigo).Result.First();
        }

    }
}