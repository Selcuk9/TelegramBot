using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Telegram_bot_Beta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi");
            //Можно РАБОТАТЬ С ДВУМЯ БОТАМИ @burtimonbot & @selcukdark
            // Link Adress
            string link = "https://api.telegram.org/bot";
            //Tokens Array
            List<string> tokens =new List<string> {"881849162:AAFum6rKVwIVp0Xc0vCwOHxyT8KFmFFVzn8", "891133330:AAENCF94oJFKJk03wzZf5qG6h52Y4V9-s-4" };
            GetMessage getMessage = new GetMessage();
            int botCount = 0;
            foreach(string s in tokens)
            {
                botCount++;
                //Async start procedure GetUpdates for each token 
                Console.WriteLine($"Bot {botCount} already started!");
                Task.Factory.StartNew(() => getMessage.GetUpdates(s, link));
            }
            Console.WriteLine("Server is working!\nI am waiting Messages!");
            Console.ReadKey();

        }
    }
}
