using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReaderBot.Controllers
{
    class Bot
    {
        readonly private static TelegramBotClient _botClient = new TelegramBotClient(Configuration.Token);
        readonly private static CancellationTokenSource _cts = new();

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
                // first row
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "Кнопка 1", callbackData: "post"),
                    InlineKeyboardButton.WithCallbackData(text: "Кнопка 2", callbackData: "12"),
                },

            });

        public void Start()
        {
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };

            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                            pollingErrorHandler: HandlePollingErrorAsync,
                            receiverOptions: receiverOptions,
                            cancellationToken: _cts.Token
                        );
        }

        async Task<Task> HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery is { } data)
            {
                Console.WriteLine($"Received a ");
            }

            if (update.Message is { } message && message.Text is { } messageText)
            {
                await BotRoute.RouteMessageAsync(message);
            }

            return Task.CompletedTask;
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        protected static async Task<Task> SendMessage(ChatId chatId, string text, ReplyKeyboardMarkup keyboard)
        {
            Message sentMessage = await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: keyboard,
                cancellationToken: _cts.Token);
            return Task.CompletedTask;
        }
    }
}
