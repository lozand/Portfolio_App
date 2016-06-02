using System;

namespace ATF.Model
{
    public class StockHistory
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public DateTime ObservationTime { get; set; }
        public double Price { get; set; }
        public bool IsEod { get; set; } 
    }
}
