using System;
using ATF.Model;
using System.Collections.Generic;

namespace Portfolio_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your username to continue");
            string userName = Console.ReadLine();

            ATF.Data.Service service = new ATF.Data.Service(userName);

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
                        Console.WriteLine("bstock <symbol> <quantity> - buy a stock");
                        Console.WriteLine("sstock <symbol> <quantity> - sell a stock");
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
                        try
                        {
                            service.BuyStock(input[1], int.Parse(input[2]));
                            Console.WriteLine("You are bought a stock; good job!");
                        }
                        catch
                        {
                            Console.WriteLine("This stock probably doesn't exist. You should try cstock to create it first. Just a thought");
                        }
                        break;
                    case "sstock":
                        try
                        {
                            service.SellStock(input[1], int.Parse(input[2]));
                            Console.WriteLine("You sold a stock; good job!");
                        }
                        catch
                        {
                            Console.WriteLine("This stock probably doesn't exist. You should try cstock to create it first. Just a thought");
                        }
                        break;
                    case "portfolio":
                        break;
                    case "vportfolio":
                        try
                        {
                            double value = service.GetPortfolioValue();
                            Console.WriteLine(String.Format("The value of your portfolio is ${0}", value.ToString()));
                        }
                        catch
                        {
                            Console.WriteLine("An error happened when trying to get your portfolio value. Stop it!");
                        }
                        break;
                    default:
                        Console.WriteLine("No command is like that. Type help for help, exit to exit or go away");
                        break;
                }
                message = Console.ReadLine();
                input = message.Split(' ');
                command = input[0];
            }

            //Console.WriteLine(String.Format("You entered, Symbol: {0}, Last Price: {1}, CompanyName: {2}", symbol.ToUpper(), lastprice.ToString(), companyName));

            //new Data.StockRepository().CreateStock(symbol, lastprice, companyName);
        }
    }
}
