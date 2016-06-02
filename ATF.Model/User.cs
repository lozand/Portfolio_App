using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATF.Model.Interfaces;

namespace ATF.Model
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CashValue { get; set; }
        public bool IsSignedIn { get; set; }
    }
}
