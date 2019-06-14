using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Data.SqlClient;

namespace Telegram_bot_Beta
{
    
   public class Client
    {
        public string Name { get; set; }
        static public SqlConnection ConnectBase;
        
        public async void ConnectingBaseAsync(string name, List<string> tokens)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\79899\Desktop\Telegram_bot_Beta\Telegram_bot_Beta\Bots.mdf;Integrated Security=True";
            ConnectBase = new SqlConnection(connectionString);
            await ConnectBase.OpenAsync();
            //SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand();
            if (tokens.Count > 0 && !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                command = new SqlCommand("INSERT INTO [DataBots] (Namebots) VALUES (@Namebots)", ConnectBase);
                command.Parameters.AddWithValue("NameBots", name);
                await command.ExecuteNonQueryAsync();
            }
            ConnectBase.Close();
            
        }
        public void WriteConsole(ref List<string> tokens )
        {
     
            #region Console
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Creat BotTelegram");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 1);
            #endregion
            Console.Write("Token: ");
            tokens = new List<string>( Console.ReadLine().Split(' '));
            Console.WriteLine("Название бота: ");
            Name = Console.ReadLine();
            ConnectingBaseAsync(Name, tokens);
            
            // GetClient();
        }
        public void GetClient(string notice , bool turnOn)
        {
            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(iP, 11000);
            Socket socket = new Socket(iP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка подключения к серверу "+ex.ToString());
                return;
            }
            #region SendAndReceive
            var Message = Encoding.UTF8.GetBytes(notice);
            socket.Send(Message);
            var buffer = new byte[1024];
            socket.Receive(buffer);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            #endregion

        }
    }
   
}
