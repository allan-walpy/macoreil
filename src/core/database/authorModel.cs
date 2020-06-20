using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Macoreil.Core.Database
{
    [Table(ApplicationContext.AuthorTableName)]
    public class AuthorModel
    {
        public string Id { get; set; }

        public string Login { get;  set; }

        public string DisplayName { get; set; }

        public string PublicKey { get;  set; }

        public IList<EntryModel> Entries { get; set; }
        public IList<EntryModel> EntriesId { get; set; }
    }
}
