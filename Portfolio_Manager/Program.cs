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
            Console.WriteLine("Enter Command");
            string message = Console.ReadLine();

            string[] input = message.Split(' ');
            Data.Service service = new Data.Service();
            string command = input[0];

            while (command != "exit")
            {
                switch (command)
                {
                    case "help":
                        Console.WriteLine("Here are a list of commands you can use");
                        break;
                    case "cstock":
                        Console.WriteLine("You are trying to create a stock");
                        try
                        {
                            service.CreateStock(input[1], double.Parse(input[2]), input[3]);
                        }
                        catch
                        {
                            Console.WriteLine("An error happened when trying to do the thing. Stop it!");
                        }
                        break;
                    case "bstock":
                        Console.WriteLine("You are trying to buy a stock, good job!");
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
