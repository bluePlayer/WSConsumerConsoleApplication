using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WSConsumerConsoleApplication
{
    public class MyWebServiceConsumer
    {
        String requestUrl = "https://api.github.com/orgs/dotnet/repos";

        public HttpWebRequest myHttpWebRequest;
        public HttpWebResponse myHttpWebResponse;
        public HttpRequestHeader myHttpRequestHeader;

        public MyWebServiceConsumer()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    //| SecurityProtocolType.Tls11
                    //| SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3
                       | (SecurityProtocolType)3072;


                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                myHttpWebRequest.Proxy = WebRequest.DefaultWebProxy;
                myHttpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                myHttpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                myHttpWebRequest.Accept = "application/vnd.github.v3+json";
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Host = "api.github.com";
                myHttpWebRequest.Headers.Add("Proxy-Authorization", "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");
                //myHttpWebRequest.Headers.Add("UserAgent", ".NET Foundation Repository Reporter");
                myHttpWebRequest.Headers.Add("X-GitHub-Api-Version:2022-11-28");
                myHttpWebRequest.Method = "GET";

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Console.WriteLine("\nThe HttpHeaders are \n\n\tName\t\tValue\n{0}", myHttpWebRequest.Headers);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("MyWebServiceConsumer: " + ex.Message + ", \nparam name: " + ex.ParamName);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("MyWebServiceConsumer: " + ex.Message + ", \nresponse: " + ex.Response + ", \nstatus: " + ex.Status + ", \ndata: " + ex.Data + " \nhelp link: " + ex.HelpLink);
            }
        }
    }
}
