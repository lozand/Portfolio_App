using System;
using ATF.Model.Interfaces;

namespace ATF.Model
{
    public class StockHistory : IStockHistory
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public DateTime ObservationTime { get; set; }
        public double Price { get; set; }
        public bool IsEod { get; set; } 
    }
}
