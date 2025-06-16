using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Database
{
    public class AppTaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<SubTaskModel> SubTasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public AppTaskContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Localização da pasta local da aplicação
            var databaseName = "apptask.db"; //Nome do banco de dados
            var databasePath = Path.Combine(folderPath, databaseName); // Junção do caminho e o nome do banco de dados
            optionsBuilder.UseSqlite($"Filename={databasePath}"); // Ligação com o banco de dados
        }
    }
}
