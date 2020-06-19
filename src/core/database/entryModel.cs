using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Macoreil.Core.Database
{
    [Table(ApplicationContext.EntryTableName)]
    public class EntryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ContentType StoreAs { get; set;  }

        [Required]
        public string Content { get; set; }
    }
}
