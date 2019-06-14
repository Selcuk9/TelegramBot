using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Telegram_bot_Beta
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            List<string> tokens = new List<string> { };
            Client client = new Client();
            client.WriteConsole(ref tokens);
            string link = "https://api.telegram.org/bot";
            #region Garbage
            // "881849162:AAFum6rKVwIVp0Xc0vCwOHxyT8KFmFFVzn8", "891133330:AAENCF94oJFKJk03wzZf5qG6h52Y4V9-s-4"
            //  client.GetClient(null,true);
            // ProxyGeneration proxy = new ProxyGeneration();
            #endregion
            GetMessage.ReadDataBaseAsync();
            Request(link,tokens);


            //Можно РАБОТАТЬ С ДВУМЯ БОТАМИ @burtimonbot & @selcukdark
            // Link Adress

            //Tokens Array


            Console.ReadKey();

        }
        public static void Request(string link, List<string> tokens)
        {
            GetMessage getMessage = new GetMessage();
            int botCount = 0;
            foreach (string s in tokens)
            {
                botCount++;
                //Async start procedure GetUpdates for each token 
                Console.WriteLine($"Bot {botCount} already started!");
                Task.Factory.StartNew(() => getMessage.GetUpdates(s, link));
            }
            Console.WriteLine("Server is working!\nI am waiting Messages!");

        }
    }
}
