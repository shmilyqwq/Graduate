using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Authority.Infrastructure.MyCourse
{
    public partial class MyauthorityContext : DbContext
    {
        public MyauthorityContext()
        {
        }

        public MyauthorityContext(DbContextOptions<MyauthorityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grac> Grac { get; set; }
        public virtual DbSet<Roac> Roac { get; set; }
        public virtual DbSet<TbAccess> TbAccess { get; set; }
        public virtual DbSet<TbGroup> TbGroup { get; set; }
        public virtual DbSet<TbRole> TbRole { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=Myauthority;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grac>(entity =>
            {
                entity.HasKey(e => e.Grid)
                    .HasName("PRIMARY");

                entity.ToTable("grac");

                entity.HasIndex(e => e.Aid)
                    .HasName("FK_Reference_11");

                entity.HasIndex(e => e.Gid)
                    .HasName("FK_Reference_8");

                entity.Property(e => e.Grid)
                    .HasColumnName("GRID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Grac)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK_Reference_11");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.Grac)
                    .HasForeignKey(d => d.Gid)
                    .HasConstraintName("FK_Reference_8");
            });

            modelBuilder.Entity<Roac>(entity =>
            {
                entity.HasKey(e => e.Rrid)
                    .HasName("PRIMARY");

                entity.ToTable("roac");

                entity.HasIndex(e => e.Aid)
                    .HasName("FK_Reference_6");

                entity.HasIndex(e => e.Rid)
                    .HasName("FK_Reference_5");

                entity.Property(e => e.Rrid)
                    .HasColumnName("RRID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Roac)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK_Reference_6");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Roac)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK_Reference_5");
            });

            modelBuilder.Entity<TbAccess>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PRIMARY");

                entity.ToTable("tb_access");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aname)
                    .HasColumnName("ANAME")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Enabled)
                    .HasColumnName("ENABLED")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<TbGroup>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PRIMARY");

                entity.ToTable("tb_group");

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

            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("tb_role");

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

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("tb_user");

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

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Urid)
                    .HasName("PRIMARY");

                entity.ToTable("user_role");

                entity.HasIndex(e => e.Aid)
                    .HasName("FK_Reference_10");

                entity.HasIndex(e => e.Gid)
                    .HasName("FK_Reference_4");

                entity.HasIndex(e => e.Rid)
                    .HasName("FK_Reference_2");

                entity.HasIndex(e => e.Uid)
                    .HasName("FK_Reference_1");

                entity.Property(e => e.Urid)
                    .HasColumnName("URID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK_Reference_10");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.Gid)
                    .HasConstraintName("FK_Reference_4");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK_Reference_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_Reference_1");
            });
        }
    }
}
