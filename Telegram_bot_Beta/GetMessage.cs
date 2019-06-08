using System;
using SimpleJSON;
using System.Net;
using System.Threading;


namespace Telegram_bot_Beta
{
    public class GetMessage
    {

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
