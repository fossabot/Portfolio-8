using System;
using System.ComponentModel.DataAnnotations;

namespace www.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Time { get; set; }
    }
}
