using System.ComponentModel.DataAnnotations;

namespace ReaderBot.Models
{
    class ReadableBook
    {
        [Key]
        public int Id { get; set; }
        public Book BookId { get; set; }
        public uint Sections { get; set; }
        public uint SubSections { get; set; }
        public uint Content { get; set; }
    }
}
