using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio_Manager.Model;
using Portfolio_Manager;
using AutoMapper;


namespace Portfolio_Manager.Data
{
    public class AutomapperConfig
    {
        public static void SetMappings()
        {
            Mapper.CreateMap<Model.Stock, Stock>();
            Mapper.CreateMap<Stock, Model.Stock>();

            Mapper.CreateMap<Model.User, User>();
            Mapper.CreateMap<User, Model.User>();

            Mapper.CreateMap<Model.TransactionLog, TransactionLog>();
            Mapper.CreateMap<TransactionLog, Model.TransactionLog>();

            Mapper.CreateMap<Model.Portfolio, Portfolio>();
            Mapper.CreateMap<Portfolio, Model.Portfolio>();

            Mapper.CreateMap<Model.StockHistory, StockHistory>();
            Mapper.CreateMap<StockHistory, Model.StockHistory>();
        }
        
    }
}
