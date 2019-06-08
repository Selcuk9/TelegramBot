using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using ApiAiSDK;


namespace Telegram_bot_Beta
{
    
    public enum AnswersTest
    {
        Привет,
        как,
        дела,
        я,
        отсталый,
        тест,
        сам,
    }
    
    public delegate void WriteText(object sender, TestCheck e );
    public class TestCheck : DialogFlow
    {
        // 7722045d459e4d0eb51ffa984d361e37  
        #region API
       private static AIConfiguration config = new AIConfiguration("7722045d459e4d0eb51ffa984d361e37", SupportedLanguage.Russian);
      public static ApiAi ApiMessage;
        #endregion
        public string TextMessage { get; set; }
        public int Chat_id { get; set; }
      

        public TestCheck(string textMessage, int chatId)
        {
            TextMessage = textMessage;
            Chat_id = chatId;
        }
        public static void VSWatch(string message, int chat_id, string type, string Token, string Link)
        {
            _tokenAi = "7722045d459e4d0eb51ffa984d361e37";
            language = SupportedLanguage.Russian;
            try
            {
                switch (message.ToLower())
                {
                    case "привет":    //TODO
                        {
                            message = MessageAi(message);
                            SendMessage(message, chat_id, Token, Link);
                            break;
                        }

                    case "как дела?": //TODO
                        {
                            message = MessageAi(message);
                            SendMessage(message, chat_id, Token, Link);
                            break;
                        }
                    default:
                        {
                            message = MessageAi(message);
                            SendMessage(message, chat_id, Token, Link);
                            break;
                        }
                }
            }
            catch
            {
                return;
            }
        }
        private static void SendMessage(string message, int chat_id,string Token,string Link)
        {
           
            using (WebClient webClient = new WebClient() )
            {
                while (true)
                {
                    try
                    {
                        NameValueCollection Data = new NameValueCollection();
                        if (message != "")
                        {
                            Data.Add("chat_id", chat_id.ToString());
                            Data.Add("text", message);
                            webClient.UploadValues(Link+Token + "/sendMessage", Data);
                            break;
                        }
                        else
                        {
                            message = "Я вас не понял";
                            Data.Add("chat_id", chat_id.ToString());
                            Data.Add("text", message);
                            webClient.UploadValues(Link+Token + "/sendMessage", Data);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                

                
            }
        }
    }

}


