using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ATF.StockAPI
{
    public static class YahooStockApi
    {
        public static Model.Stock GetStockPriceBySymbol(string symbol)
        {
            string csvData;
            using (WebClient web = new WebClient())
            {
                // Can do a comma-separated list here;
                csvData = web.DownloadString("http://finance.yahoo.com/d/quotes.csv?s=" + symbol +"&f=snbaopl1");
            }
            List<Price> prices = Parse(csvData);

            return MapPriceToStock(prices.First());
        }

        public static List<Price> Parse(string csvData)
        {
            List<Price> prices = new List<Price>();
            string[] rows = csvData.Replace("\r", "").Split('\n');
            foreach (string row in rows)
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] cols = row.Split(',');
                    for (int i = 0; i < cols.Count(); i++)
                    {
                        if(cols[i][0] == ' '  && i != 0)
                        {
                            cols[i - 1] = cols[i - 1] + cols[i];
                            for(int j = 0; j < cols.Length - i -1; j++)
                            {
                                cols[i + j] = cols[i + j + 1];
                            }
                        }
                    }
                    Price p = new Price();
                    p.Symbol = cols[0];
                    p.Name = cols[1];
                    p.Bid = Convert.ToDecimal(cols[2]);
                    p.Ask = Convert.ToDecimal(cols[3]);
                    p.Open = Convert.ToDecimal(cols[4]);
                    p.PreviousClose = Convert.ToDecimal(cols[5]);
                    p.Last = Convert.ToDecimal(cols[6]);
                    prices.Add(p);
                }
            }
            return prices;
        }

        public static Model.Stock MapPriceToStock(Price price)
        {
            return new Model.Stock()
            {
                LastPrice = Convert.ToDouble(price.Last),
                CompanyName = price.Name,
                Symbol = price.Symbol
            };
        }
    }
    public class Price
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Open { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Last { get; set; }
    }
}
