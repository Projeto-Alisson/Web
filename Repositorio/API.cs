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

        public static object post(string path, Model model)
        {
            Func<string, Model, Task<object>> func = async (_path, _model) =>
            {
                object model = default;
                HttpResponseMessage response = await client.PostAsJsonAsync(host + _path, _model);
                if (response.IsSuccessStatusCode)
                {
                    HttpContent content = response.Content;
                    model = await content.ReadAsAsync<object>();
                }
                return model;
            };
            return func(path, model).Result;
        }
    }
}