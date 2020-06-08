using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apicall
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            //httpMethod = httpVerb.GET;
        }

        public async Task<string> makeRequest()
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(endPoint);
            request.Method = httpVerb.GET.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode !=HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode);
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream !=null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = await reader.ReadToEndAsync();
                        }
                    }
                }
            }

            return strResponseValue;
        }

        public async Task<string> makeRequest2()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(endPoint))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();                        
                        if (data !=null)
                        {
                            return data;
                        }
                    }
                }
            }

            return string.Empty;
        }


        public async Task<string> Postala()
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(endPoint);
            request.Method = httpVerb.POST.ToString();
            request.ContentType = "application/json";
                        
            string postdata = "{\"name\":\"test\",\"job\":\"danisman\"}";

            using (Stream requestStream = request.GetRequestStream())
            {                    
                using (StreamWriter sw = new StreamWriter(requestStream))
                {
                    await sw.WriteAsync(postdata);
                    HttpWebRequest response = (HttpWebRequest)WebRequest.CreateHttp(endPoint);
                    using (StreamReader reader = new StreamReader(response.GetRequestStream()))
                    {
                        var sonuc = await reader.ReadToEndAsync();
                        return sonuc;
                    }
                }
            }                        
        }

        public async Task<string> Postala2(string name, string job)
        {
            //excel range/table to datatable, sonra datatable to json, veya varsa doğrudan excel to json
            var inputdata = new Dictionary<string, string>
            {
                {"name",name},
                {"job",job }
            };
            var input = new FormUrlEncodedContent(inputdata);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(endPoint,input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public async Task<string> PUT(string name, string job)
        {
            //excel range/table to datatable, sonra datatable to json, veya varsa doğrudan excel to json
            var inputdata = new Dictionary<string, string>
            {
                {"name",name},
                {"job",job }
            };
            var input = new FormUrlEncodedContent(inputdata);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync(endPoint, input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
