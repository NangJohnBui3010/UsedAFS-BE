using Microsoft.EntityFrameworkCore;

namespace UsedAFS_BE.Entities
{
    public class CoreContext : DbContext
    {
        public virtual DbSet<BookEntity> Books { get; set; }
        public virtual DbSet<PersonEntity> Persons { get; set; }

        public string DbPath { get; }

        public CoreContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "UsedAFS.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
