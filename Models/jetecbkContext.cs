using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BkServer.Models
{
    public partial class jetecbkContext : DbContext
    {
        public jetecbkContext()
        {
        }

        public jetecbkContext(DbContextOptions<jetecbkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegUser> RegUser { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=user;Password=52872028;Database=jetecbk;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("reg_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.RegistKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistTime)
                    .HasColumnName("registTime")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasColumnName("user_pwd")
                    .HasMaxLength(35);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(30);

                entity.Property(e => e.Usergroup)
                    .IsRequired()
                    .HasColumnName("usergroup")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(30)
                    .HasComment("帳號");

                entity.Property(e => e.Allowdate)
                    .IsRequired()
                    .HasColumnName("allowdate")
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.ProxyId)
                    .HasColumnName("proxy_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasColumnName("user_pwd")
                    .HasMaxLength(35)
                    .HasComment("密碼");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(30)
                    .HasComment("類型");

                entity.Property(e => e.Usergroup)
                    .IsRequired()
                    .HasColumnName("usergroup")
                    .HasMaxLength(40)
                    .HasComment("公司");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
