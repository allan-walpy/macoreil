using Microsoft.EntityFrameworkCore;

namespace Macoreil.Core.Database
{

    public class ApplicationContext : DbContext
    {
        public const string AuthorTableName = "Author";
        public const string EntryTableName = "Entry";

    }

}
