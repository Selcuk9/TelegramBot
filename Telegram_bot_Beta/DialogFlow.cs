using System;
using ApiAiSDK;
using ApiAiSDK.Model;


namespace Telegram_bot_Beta
{
  public class DialogFlow
    {
        protected static string _tokenAi = "7722045d459e4d0eb51ffa984d361e37";
        protected static SupportedLanguage language = SupportedLanguage.Russian;
        protected static AIConfiguration config = new AIConfiguration(_tokenAi, language);
        public static ApiAi Apiai;
        public static string MessageAi(string messageText)
        {
            Apiai = new ApiAi(config);
            var response = Apiai.TextRequest(messageText);
            string message = response.Result.Fulfillment.Speech;
            return message;
        }
    }
}
