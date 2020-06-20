using Microsoft.EntityFrameworkCore;

namespace Macoreil.Core.Database
{
    public class DatabaseService
    {
        private string _connectionString;

        public ApplicationContext Context
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var options = optionsBuilder
                    .UseMySQL(this._connectionString)
                    .Options;

                return new ApplicationContext(options);
            }
        }

        public DatabaseService(string connectionString)
        {
            this._connectionString = connectionString;
        }
    }
}
