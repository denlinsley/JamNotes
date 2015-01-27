using JamNotes.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JamNotes.DAL
{
    public class NotesContext : DbContext
    {
        public NotesContext() : base("NotesContext") // pass in the name of the connection string in Web.config
        { 
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<FeaturedJam> FeaturedJams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // disables pluralization of table names
        }
    }
}