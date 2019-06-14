using System;
using SimpleJSON;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Telegram_bot_Beta
{
    public class GetMessage : Client 
    {
        //public bool Check { get; set; }
       static List<string> data = new List<string>();
        public static async void ReadDataBaseAsync()
        {
           //// await ConnectBase.OpenAsync();

           // SqlDataReader reader = null;
           // var command = new SqlCommand("SELECT * FROM [DataBots]",ConnectBase);
            
           // try
           // {
           //     reader = await command.ExecuteReaderAsync();
           //     while (await reader.ReadAsync())
           //     {
           //         data.Add(reader["Id"].ToString());
           //     }
           // }
           // catch (Exception ex)
           // {
           //     Console.WriteLine("Ошибка при записи из базы {0}", ex.ToString());
           // }
           // finally
           // {
           //     if (reader != null)
           //         reader.Close();
           // }
        }



        public GetMessage(){}

        public void GetUpdates(string Token, string Link)
        {
            

            int Update_id = 0;
            int Chat_Id = default(int);
            string Message = null;
            while (true)
            {
                using (WebClient webClient = new WebClient())
                {
                    
                   // Console.WriteLine("Waiting for a message");
                    string response = webClient.DownloadString(Link + Token + "/getupdates?offset="+ + (Update_id+1));
                    GetClient($"Подключен бот № 1 Название бота: {Name}",true);
                    if (response.Length <= 23)
                        continue;
                    
                    var N = JSON.Parse(response);
                    foreach (JSONNode r in N["result"].AsArray)
                    {
                        Message = r["message"]["text"];                       
                        Chat_Id = r["message"]["chat"]["id"].AsInt;
                        Console.WriteLine($"Message - {Message}");
                        Update_id = r["update_id"].AsInt;
                        try
                        {
                            response = response.Remove(0, response.LastIndexOf("\"" + "text" + "\""));
                        }
                        catch (Exception)
                        {
                            continue;                         
                        }
                    }
                    response = response.Remove(response.IndexOf(":")).Replace("\"", "");
                    TestCheck.VSWatch(Message, Chat_Id, response,Token,Link);
                }

            }
            
        }
      
    }


}
