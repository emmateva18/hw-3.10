using BaseLibS.Util;
using com.sun.xml.@internal.bind.v2.schemagen.xmlschema;
using jdk.nashorn.@internal.runtime;
using org.omg.CORBA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GlobalConstants = jdk.nashorn.@internal.runtime.GlobalConstants;

namespace hw.Requests
{
    internal class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new IHttpHeaderCollection();

            this.ParseRequest(requestString);

        }
        private bool IsValidRequestLine(string[] requestLine)
        {
            if(requestLine.Length==3)
            {
                if (requestLine[3] == "HTTP/1.1")
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            Console.WriteLine(requestLine[0]);
        }

        private void ParseRequstUrl(string[] requestLine)
        {
            Console.WriteLine(requestLine[1]);
        }

        private void ParseRequestPath(string[] requestLine)
        {
        }
        private void ParseHeaders(string[] requestContent)
        {

        }

        private void ParseCookies()
        {

        }
        private void ParseQueryParameters(string formData)
        { 
        }
        private void ParseRequestParameters(string formData)
        {

        }
        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(separator: new[] { GlobalConstants.HttpNewLine },
                                                               StringSplitOptions.None);
            string[] requestLine = splitRequestContent[0].Trim().Split(separator: new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new HttpRequestException();
            }
            this.ParseRequestMethod(requestLine);
            this.ParseRequstUrl(requestLine);
            this.ParseRequestPath(requestLine);

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }



        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
        
    }
}
