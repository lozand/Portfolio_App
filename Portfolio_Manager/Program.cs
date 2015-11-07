using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Portfolio_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your username to continue");
            string userName = Console.ReadLine();

            Data.Service service = new Data.Service(userName);

            Console.WriteLine("Enter Command");
            string message = Console.ReadLine();

            string[] input = message.Split(' ');
            string command = input[0];

            while (command != "exit")
            {
                switch (command)
                {
                    case "help":
                        Console.WriteLine("Here are a list of commands you can use");
                        Console.WriteLine("cstock <symbol> <price> <company_name> - create a stock");
                        Console.WriteLine("bstock - buy a stock");
                        Console.WriteLine("sstock - sell a stock");
                        Console.WriteLine("vportfolio - get the value of your portfolio");
                        Console.WriteLine("lportfolio - list your portfolio");
                        Console.WriteLine("exit - ... to exit");
                        break;
                    case "cstock":
                        Console.WriteLine("You are trying to create a stock");
                        try
                        {
                            service.CreateStock(input[1], double.Parse(input[2]), input[3]);
                            Console.WriteLine("Stock Creation Successful!!");
                        }
                        catch
                        {
                            Console.WriteLine("An error happened when trying to do the thing. Stop it!");
                        }
                        break;
                    case "bstock":
                        try {
                            Console.WriteLine("You are trying to buy a stock, good job!");
                        }
                        catch
                        {
                            Console.WriteLine("This stock probably doesn't exist. You should try cstock to create it first. Just a thought");
                        }
                        break;
                    case "sstock":
                        Console.WriteLine("You are trying to seel a stock");
                        break;
                    case "portfolio":
                        Console.WriteLine("You tried to list your portfolio! Nice!");
                        break;
                    default:
                        Console.WriteLine("No command is like that. Type help for help, exit to exit or go away");
                        break;
                }

                command = Console.ReadLine().Split(' ')[0];
            }

            //Console.WriteLine(String.Format("You entered, Symbol: {0}, Last Price: {1}, CompanyName: {2}", symbol.ToUpper(), lastprice.ToString(), companyName));

            //new Data.StockRepository().CreateStock(symbol, lastprice, companyName);
        }
    }
}
