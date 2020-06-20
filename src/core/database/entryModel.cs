using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Macoreil.Core.Database
{
    [Table(ApplicationContext.EntryTableName)]
    public class EntryModel
    {
        public enum VisibilityType
        {
            Self,
            Public
        }

        public enum ContentType
        {
            None,
            Text,
            File
        }

        public string Id { get; set; }

        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public VisibilityType AvailableTo { get; set; }

        public string Title { get; set; }

        public ContentType StoredAs { get; set; }

        public string Content { get; set; }
    }
}
