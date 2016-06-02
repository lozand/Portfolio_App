using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model;
using ATF.Model.Interfaces;
using AutoMapper;


namespace ATF.Data
{
    public class AutomapperConfig
    {
        public static void SetMappings()
        {
            Mapper.CreateMap<IStock, Stock>();
            Mapper.CreateMap<Stock, Model.Stock>();

            Mapper.CreateMap<IUser, User>();
            Mapper.CreateMap<User, Model.User>();

            Mapper.CreateMap<ITransactionLog, TransactionLog>();
            Mapper.CreateMap<TransactionLog, Model.TransactionLog>();

            Mapper.CreateMap<Model.Portfolio, Portfolio>();
            Mapper.CreateMap<Portfolio, Model.Portfolio>();

            Mapper.CreateMap<IStockHistory, StockHistory>();
            Mapper.CreateMap<StockHistory, Model.StockHistory>();
        }
        
    }
}
