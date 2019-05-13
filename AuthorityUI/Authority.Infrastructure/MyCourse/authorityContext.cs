using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Authority.Infrastructure.MyCourse
{
    public partial class AuthorityContext : DbContext
    {
        public AuthorityContext()
        {
        }

        public AuthorityContext(DbContextOptions<AuthorityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Grac> Grac { get; set; }
        public virtual DbSet<Roac> Roac { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAcc> UserAcc { get; set; }
        public virtual DbSet<UserTe> UserTe { get; set; }
        public virtual DbSet<UserRo> UserRo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=authority;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PRIMARY");

                entity.ToTable("author");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aname)
                    .HasColumnName("ANAME")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Enabled)
                    .HasColumnName("ENABLED")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Grac>(entity =>
            {
                entity.HasKey(e => e.Grid)
                    .HasName("PRIMARY");

                entity.ToTable("grac");

                entity.Property(e => e.Grid)
                    .HasColumnName("GRID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Roac>(entity =>
            {
                entity.HasKey(e => e.Rrid)
                    .HasName("PRIMARY");

                entity.ToTable("roac");

                entity.Property(e => e.Rrid)
                    .HasColumnName("RRID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rdesc)
                    .HasColumnName("RDESC")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PRIMARY");

                entity.ToTable("team");

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gdesc)
                    .HasColumnName("GDESC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Gname)
                    .HasColumnName("GNAME")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(20)");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Uname)
                    .HasColumnName("UNAME")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<UserAcc>(entity =>
            {
                entity.HasKey(e => e.Uaid)
                    .HasName("PRIMARY");

                entity.ToTable("useracc");

                entity.Property(e => e.Uaid)
                    .HasColumnName("UAID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserRo>(entity =>
            {
                entity.HasKey(e => e.Urid)
                    .HasName("PRIMARY");

                entity.ToTable("usero");

                entity.Property(e => e.Urid)
                    .HasColumnName("URID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserTe>(entity =>
            {
                entity.HasKey(e => e.Ugid)
                    .HasName("PRIMARY");

                entity.ToTable("UserTe");

                entity.Property(e => e.Ugid)
                    .HasColumnName("UGID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("int(11)");
            });
        }
    }
}
