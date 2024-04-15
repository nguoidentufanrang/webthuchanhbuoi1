using System.ComponentModel.DataAnnotations;

namespace webthuchanhbuoi1.Models
{
    public class Publishers
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<Books>? Book { get; set; }
    }
}
