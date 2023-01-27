using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ReaderBot.Controllers.Actions
{
    class CommandStart: BotRoute
    {
        private Message _message;
        public CommandStart(Message message)
        {
            _message = message;
            SignUp();
        }

        private void SignUp()
        {
            using (ApplicationContext db = new())
            {
                var findUser = db.Users.FirstOrDefault(u => u.UserId == _message.From.Id);
                if (findUser != null)
                {
                    return;
                }

                Models.User user = new()
                {
                    Name = _message.From.Username,
                    UserId = _message.From.Id,
                    BooksId = null,
                    RegisterDate = DateTime.Now
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
