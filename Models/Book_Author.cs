﻿namespace webthuchanhbuoi1.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }
        public Books? Book { get; set; }
        public Authors? Author { get; set; }
    }
}
