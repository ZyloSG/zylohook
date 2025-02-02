using System;
using System.IO;
using System.Net;
using System.Text;

namespace Zylohook
{
    public static class Requester
    {
        public static string Send(string URL, JsonPact body = null, string method = "POST")
        {
            if (method == "POST")
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    string jsonData = body.ToString();

                    byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);
                    request.ContentLength = dataBytes.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(dataBytes, 0, dataBytes.Length);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string responseText = reader.ReadToEnd();
                            return responseText;
                        }
                    }
                }
                catch (WebException ex)
                {
                    using (var errorResponse = (HttpWebResponse)ex.Response)
                    {
                        if (errorResponse != null)
                        {
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                string errorText = reader.ReadToEnd();
                                Console.WriteLine("Response error, probably ratelimited !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Response error, probably ratelimited !");
                        }
                    }
                }
            }
            else if (method == "GET")
            {
                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(URL);
                    return response;
                }
            }
            else if (method == "DELETE")
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "DELETE";
            }
                return "";
        }
    }
}
