using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BkServer.Models
{
    public partial class jetec_join_systemContext : DbContext
    {
        public jetec_join_systemContext()
        {
        }

        public jetec_join_systemContext(DbContextOptions<jetec_join_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AlarmLog> AlarmLog { get; set; }
        public virtual DbSet<CustEmail> CustEmail { get; set; }
        public virtual DbSet<CustLinekey> CustLinekey { get; set; }
        public virtual DbSet<CustMast> CustMast { get; set; }
        public virtual DbSet<CustSid> CustSid { get; set; }
        public virtual DbSet<DeviceSet> DeviceSet { get; set; }
        public virtual DbSet<DeviceShow> DeviceShow { get; set; }
        public virtual DbSet<ProxyCompany> ProxyCompany { get; set; }
        public virtual DbSet<RemoteAlarm> RemoteAlarm { get; set; }
        public virtual DbSet<RemoteAlarmRecent> RemoteAlarmRecent { get; set; }
        public virtual DbSet<Tokenlist> Tokenlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=user;Password=52872028;Database=jetec_join_system;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.Subid, e.Cid })
                    .HasName("PRIMARY");

                entity.ToTable("account");

                entity.Property(e => e.Subid)
                    .HasColumnName("subid")
                    .HasMaxLength(100);

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(100);

                entity.Property(e => e.Subpwd)
                    .IsRequired()
                    .HasColumnName("subpwd")
                    .HasMaxLength(32);

                entity.Property(e => e.Supervisor).HasColumnName("supervisor");
            });

            modelBuilder.Entity<AlarmLog>(entity =>
            {
                entity.ToTable("alarm_log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Alarmtime)
                    .IsRequired()
                    .HasColumnName("alarmtime")
                    .HasMaxLength(25)
                    .HasComment("警報時間");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(50);

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("sname")
                    .HasMaxLength(100);

                entity.Property(e => e.Textlog)
                    .IsRequired()
                    .HasColumnName("textlog");
            });

            modelBuilder.Entity<CustEmail>(entity =>
            {
                entity.ToTable("cust_email");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Receive)
                    .HasColumnName("receive")
                    .HasColumnType("int(1)")
                    .HasComment("是否接收通知");

                entity.Property(e => e.Undelete)
                    .HasColumnName("undelete")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<CustLinekey>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("cust_linekey");

                entity.HasIndex(e => e.Cid)
                    .HasName("cid")
                    .IsUnique();

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Linekey)
                    .IsRequired()
                    .HasColumnName("linekey")
                    .HasMaxLength(50);

                entity.Property(e => e.Setdate)
                    .IsRequired()
                    .HasColumnName("setdate")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CustMast>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("cust_mast");

                entity.HasIndex(e => e.Cid)
                    .HasName("cid")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(15);

                entity.Property(e => e.Allowstatus)
                    .IsRequired()
                    .HasColumnName("allowstatus")
                    .HasMaxLength(5)
                    .HasComment("帳號狀態");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Enddate)
                    .IsRequired()
                    .HasColumnName("enddate")
                    .HasMaxLength(15)
                    .HasComment("到期日期");

                entity.Property(e => e.Function)
                    .IsRequired()
                    .HasColumnName("function")
                    .HasMaxLength(20);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasColumnName("group")
                    .HasMaxLength(40);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProxyId)
                    .HasColumnName("proxy_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(32);

                entity.Property(e => e.Registdate)
                    .IsRequired()
                    .HasColumnName("registdate")
                    .HasMaxLength(15);

                entity.Property(e => e.Registtime)
                    .IsRequired()
                    .HasColumnName("registtime")
                    .HasMaxLength(15);

                entity.Property(e => e.Renew)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Savedays)
                    .HasColumnName("savedays")
                    .HasColumnType("int(5)");

                entity.Property(e => e.TokenQty)
                    .HasColumnName("Token_Qty")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Vip)
                    .HasColumnName("vip")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<CustSid>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.Sid })
                    .HasName("PRIMARY");

                entity.ToTable("cust_sid");

                entity.HasComment("客人帳戶下的Sensor");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasMaxLength(20);

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("s_name")
                    .HasMaxLength(30);

                entity.Property(e => e.SType)
                    .IsRequired()
                    .HasColumnName("s_type")
                    .HasMaxLength(15);

                entity.Property(e => e.Typename)
                    .HasColumnName("typename")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<DeviceSet>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.Sid })
                    .HasName("PRIMARY");

                entity.ToTable("device_set");

                entity.HasIndex(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasMaxLength(20);

                entity.Property(e => e.Cl)
                    .IsRequired()
                    .HasColumnName("cl")
                    .HasMaxLength(50);

                entity.Property(e => e.Dp)
                    .IsRequired()
                    .HasColumnName("dp")
                    .HasMaxLength(50);

                entity.Property(e => e.Eh)
                    .IsRequired()
                    .HasColumnName("eh")
                    .HasMaxLength(50);

                entity.Property(e => e.El)
                    .IsRequired()
                    .HasColumnName("el")
                    .HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ih)
                    .IsRequired()
                    .HasColumnName("ih")
                    .HasMaxLength(50);

                entity.Property(e => e.Il)
                    .IsRequired()
                    .HasColumnName("il")
                    .HasMaxLength(50);

                entity.Property(e => e.Pv)
                    .IsRequired()
                    .HasColumnName("pv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceShow>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.Sid })
                    .HasName("PRIMARY");

                entity.ToTable("device_show");

                entity.HasIndex(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasMaxLength(20);

                entity.Property(e => e.Chl)
                    .IsRequired()
                    .HasColumnName("chl")
                    .HasMaxLength(20);

                entity.Property(e => e.Display)
                    .IsRequired()
                    .HasColumnName("display")
                    .HasMaxLength(20);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowcnt)
                    .HasColumnName("rowcnt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Showtime)
                    .IsRequired()
                    .HasColumnName("showtime")
                    .HasMaxLength(20);

                entity.Property(e => e.Sw)
                    .IsRequired()
                    .HasColumnName("sw")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProxyCompany>(entity =>
            {
                entity.ToTable("proxy_company");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RemoteAlarm>(entity =>
            {
                entity.ToTable("remote_alarm");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Dp)
                    .IsRequired()
                    .HasColumnName("dp")
                    .HasMaxLength(15);

                entity.Property(e => e.Eh)
                    .HasColumnName("eh")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.El)
                    .HasColumnName("el")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SendDate)
                    .HasColumnName("send_date")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SendTime)
                    .HasColumnName("send_time")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(20);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<RemoteAlarmRecent>(entity =>
            {
                entity.ToTable("remote_alarm_recent");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AlarmTime)
                    .HasColumnName("Alarm_time")
                    .HasMaxLength(18)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AutoSwitch)
                    .IsRequired()
                    .HasColumnName("auto_switch")
                    .HasMaxLength(31);

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.Device)
                    .HasColumnName("device")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dp)
                    .IsRequired()
                    .HasColumnName("dp")
                    .HasMaxLength(30);

                entity.Property(e => e.Eh)
                    .HasColumnName("eh")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.El)
                    .HasColumnName("el")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RelayStatus)
                    .HasColumnName("relay_status")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("s_name")
                    .HasMaxLength(30);

                entity.Property(e => e.SendDate)
                    .HasColumnName("send_date")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SendTime)
                    .HasColumnName("send_time")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(20);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Typename)
                    .IsRequired()
                    .HasColumnName("typename")
                    .HasMaxLength(200);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tokenlist>(entity =>
            {
                entity.ToTable("tokenlist");

                entity.HasComment("Token");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(20);

                entity.Property(e => e.LoginTime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
