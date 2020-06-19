using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Macoreil.Core.Database
{
    [Table(ApplicationContext.AuthorTableName)]
    public class AuthorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get;  set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string PublicKey { get;  set; }

        public ICollection<EntryModel> Entries { get; set; }
    }
}
