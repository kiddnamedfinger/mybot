using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderBot.Models
{
    class Book
    {
        [Key]
        public int Id { get; set; }
        public Guid FileName { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string City { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        public DateTime LoadDate { get; set; }
        public int UserLoadId { get; set; }
    }
}
