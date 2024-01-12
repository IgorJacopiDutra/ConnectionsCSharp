
using ConnectionsWindowsFormsCSharp.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace ConnectionsWindowsFormsCSharp.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Cliente> CLIENTES { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFirebird("User=SYSDBA;Password=masterkey;Database=C:\\geiewin\\SubProjetos\\Curso\\Git\\ConnectionsWindowsFormsCSharp\\data\\DATA.FDB;DataSource=localhost;Port=3051");
        }
        public long GetNextClienteId()  // Use long to accommodate larger values
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    // Open connection if not already open
                    if (context.Database.GetDbConnection().State != ConnectionState.Open)
                    {
                        context.Database.OpenConnection();
                    }

                    using (var command = context.CreateCommand())
                    {
                        command.CommandText = "SELECT GEN_ID(GEN_CLIENTES, 1) FROM RDB$DATABASE";
                        return (long)command.ExecuteScalar();  // Cast to long
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                throw new DataException("Failed to retrieve next client ID", ex);
            }
        }

        protected DbCommand CreateCommand()
        {
            // Check connection state before creating command
            if (Database.GetDbConnection().State != ConnectionState.Open)
            {
                throw new InvalidOperationException("Connection must be valid and open before creating commands.");
            }

            return Database.GetDbConnection().CreateCommand();
        }
    }
}
