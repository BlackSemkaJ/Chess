namespace ChessAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelChessDB : DbContext
    {
        public ModelChessDB()
            : base("name=ModelChessDB")
        {
        }

        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.FEN)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.STATUS)
                .IsUnicode(false);
        }
    }
}
