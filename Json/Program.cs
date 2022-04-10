using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System;
using Newtonsoft.Json;
using System.Xml;

namespace Json
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://www.cbar.az/currencies/08.04.2022.xml");

            var msg = await stringTask; 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(msg);
            Console.Write(msg);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            Console.WriteLine(jsonText);
            System.IO.File.WriteAllText("C:\\Users\\user\\Desktop\\" + "test.json", jsonText);

        }
    }
}
