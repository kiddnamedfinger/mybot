using FB2Library;
using System;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using ReaderBot.Models;
using System.Linq;
using Telegram.Bot;
using ReaderBot.Controllers;

namespace ReaderBot
{
    class Program
    {
        static void Main()
        {
            //using (ApplicationContext db = new())
            //{
            //    //User user = new User { Name = "Admin", UserId = -1, BooksId = null, RegisterDate = DateTime.Now};
            //    //db.Users.Add(user);
            //    //db.SaveChanges();
            //}

            Bot bot = new();
            Console.Title = Configuration.Name;
            bot.Start();
            Console.ReadLine();
        }
    }
}
