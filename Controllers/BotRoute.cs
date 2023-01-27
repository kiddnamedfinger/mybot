using ReaderBot.Controllers.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ReaderBot.Controllers
{
    class BotRoute: Bot
    {
        protected static readonly string _errorMessage = "Для навигации используйте клавиатуру";

        static public async Task RouteMessageAsync(Message message)
        {
            if (message.Text == "/start")
            {
                CommandStart commandStart = new(message);
                await SendMessage(message.Chat.Id, _errorMessage, null);
            }

            /* if only text */
            else 
            {
                await SendMessage(message.Chat.Id, _errorMessage, null);
            }
        } 
    }
}
