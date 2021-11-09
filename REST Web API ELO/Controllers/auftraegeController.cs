using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_Web_API_ELO.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Net;
using System.Reflection;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_Web_API_ELO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class auftraegeController : ControllerBase
    {
        public static string ausgabe;
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            yield return "Auftragsnummer in URL eingeben!";
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(string id)
        {

            var Auftragsnummer = id;

            string URI_KEYWORDING = "http://elo.helmut-meeth.com:9090/ELOrest-12.04.000/api/search?where=KEYWORDING&words=" + Auftragsnummer;

            var request = (HttpWebRequest)WebRequest.Create(URI_KEYWORDING);

            request.Method = "GET";
            // request.UserAgent = RequestConstants.UserAgentValue;
            //  request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content_KEYWORDING = string.Empty;

            request.Headers.Add("Authorization", "Basic ****************************");

            request.ContentType = "application/json";
            var response_KEYWORDING = (HttpWebResponse)request.GetResponse();
            //      response.Headers.Add("X-Amz-date",DateTime.UtcNow.ToString("yyyyMMddThhmmss")+"Z");
            using (var stream_KEYWORDING = response_KEYWORDING.GetResponseStream())
            {
                using (var sr_KEYWORDING = new StreamReader(stream_KEYWORDING))
                {
                    content_KEYWORDING = sr_KEYWORDING.ReadToEnd();
                }
            }

            JArray jArray = new JArray();
            jArray = JArray.Parse(content_KEYWORDING);

            var result = jArray.ToObject<List<Search_Response>>();

            string URI_url;

            for (int i = 0; i < result.Count; i++)
            {
                URI_url = "http://elo.helmut-meeth.com:9090/ELOrest-12.04.000/api/files/" + result[i].id; 

                request = (HttpWebRequest)WebRequest.Create(URI_url);

                request.Method = "GET";

                var content_url = string.Empty;

                request.Headers.Add("Authorization", "Basic ***************");

                request.ContentType = "application/json";
                var response_url = (HttpWebResponse)request.GetResponse();

                using (var stream_url = response_url.GetResponseStream())
                {
                    using (var sr_url = new StreamReader(stream_url))
                    {
                        content_url = sr_url.ReadToEnd();
                    }
                }

                File_Response result2 = JsonConvert.DeserializeObject<File_Response>(content_url);
                String url_lokal = result2.versions[0].url;
                var url_public = url_lokal.Replace("vsrvelo2", "elo.helmut-meeth.com");
                ausgabe = ("Auftragsnummer: " + Auftragsnummer + "   |   " + "ID: " + result[i].id + "  |  " + "Dateiname: " + result[i].name + "  |  " + "URL: " + url_public);
                //Console.WriteLine("\n" + "ID: " + result[i].id + "\n" + "Dateiname: " + result[i].name + "\n" + url_public + "\n");
                //Process.Start(new ProcessStartInfo { FileName = url_public, UseShellExecute = true });
            }
            yield return ausgabe;    
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
