using System;

namespace ATF.Model.Interfaces
{
    public interface IStockHistory
    {
        int Id { get; set; }
        int StockId { get; set; }
        DateTime ObservationTime { get; set; }
        double Price { get; set; }
        bool IsEod { get; set; }
    }
}
