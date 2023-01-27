using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReaderBot.Models
{
    class User
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<ReadableBook> BooksId { get; set; } = new();
    }
}
