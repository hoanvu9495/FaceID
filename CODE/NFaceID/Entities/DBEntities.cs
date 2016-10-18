namespace NFaceID.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }

        public virtual DbSet<ATTENDANCE> ATTENDANCEs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<HISTORY> HISTORies { get; set; }
        public virtual DbSet<PERSONAL> PERSONALs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATTENDANCE>()
                .Property(e => e.IMG_IN)
                .IsUnicode(false);

            modelBuilder.Entity<ATTENDANCE>()
                .Property(e => e.IMG_OUT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CMT)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.IMG_FACE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.ATTENDANCEs)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.ID_EMP);

            modelBuilder.Entity<HISTORY>()
                .Property(e => e.IMG_FACE)
                .IsUnicode(false);

            modelBuilder.Entity<HISTORY>()
                .Property(e => e.IMG)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONAL>()
                .Property(e => e.IMG_FACE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONAL>()
                .Property(e => e.IMG)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONAL>()
                .HasMany(e => e.EMPLOYEEs)
                .WithOptional(e => e.PERSONAL)
                .HasForeignKey(e => e.ID_PS);

            modelBuilder.Entity<PERSONAL>()
                .HasMany(e => e.HISTORies)
                .WithOptional(e => e.PERSONAL)
                .HasForeignKey(e => e.ID_PER);
        }
    }
}
