using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RestSharp;

namespace ATF.StockAPI
{
    public static class MarketOnDemand
    {
        public static string GetStock(string symbol)
        {
            var stockResult = "";

            var client = new RestClient("http://dev.markitondemand.com");
            
            var request = new RestRequest(String.Format("MODApis/Api/v2/Quote/json?symbol={0}", symbol));
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);
            stockResult = response.Content;

            return stockResult;
        }

     
    }
}
