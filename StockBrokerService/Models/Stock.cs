namespace StockBrokerService.Models
{
    public class Stock
    {
        public string StockSymbol { get; set; }
        public int Quantity { get; set; }
        public double CurrentValue { get; set; }
    }
}