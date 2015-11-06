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
            Mapper.CreateMap<Model.Stock, Data.Stock>();
        }
        
    }
}
