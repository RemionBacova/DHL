using System;
using DHLWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DHLWebAPI.Data
{
    public partial class DHLContext : DbContext
    {

        public DHLContext(DbContextOptions<DHLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAddressType> TblAddressType { get; set; }
        public virtual DbSet<TblCardStatus> TblCardStatus { get; set; }
        public virtual DbSet<TblCards> TblCards { get; set; }
        public virtual DbSet<TblCustomerAddress> TblCustomerAddress { get; set; }
        public virtual DbSet<TblCustomerDiscount> TblCustomerDiscount { get; set; }
        public virtual DbSet<TblCustomerLogs> TblCustomerLogs { get; set; }
        public virtual DbSet<TblCustomerStatus> TblCustomerStatus { get; set; }
        public virtual DbSet<TblCustomerType> TblCustomerType { get; set; }
        public virtual DbSet<TblCustomers> TblCustomers { get; set; }
        public virtual DbSet<TblDiscountType> TblDiscountType { get; set; }
        public virtual DbSet<TblDiscounts> TblDiscounts { get; set; }
        public virtual DbSet<TblProductDiscount> TblProductDiscount { get; set; }
        public virtual DbSet<TblProducts> TblProducts { get; set; }
        public virtual DbSet<TblProfilePermission> TblProfilePermission { get; set; }
        public virtual DbSet<TblShipments> TblShipments { get; set; }
        public virtual DbSet<TblToolPermission> TblToolPermission { get; set; }
        public virtual DbSet<TblTools> TblTools { get; set; }
        public virtual DbSet<TblTransactionLogs> TblTransactionLogs { get; set; }
        public virtual DbSet<TblUserType> TblUserType { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.HasKey(x => x.IdAddress);

                entity.ToTable("tbl_address");

                entity.Property(e => e.AddressLabel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LunchTimeEnd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LunchTimeStart)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OpenTimeEnd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OpenTimeStart)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PostAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PostAddressNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostIntern)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAddressTypeNavigation)
                    .WithMany(p => p.TblAddress)
                    .HasForeignKey(x => x.IdAddressType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_addre__IdAdd__4F7CD00D");
            });

            modelBuilder.Entity<TblAddressType>(entity =>
            {
                entity.HasKey(x => x.IdAddressType);

                entity.ToTable("tbl_address_type");

                entity.Property(e => e.AdressType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCardStatus>(entity =>
            {
                entity.HasKey(x => x.IdCardStatus);

                entity.ToTable("tbl_card_status");

                entity.Property(e => e.CardStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.TblCardStatus)
                    .HasForeignKey(x => x.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_card___Updat__52593CB8");
            });

            modelBuilder.Entity<TblCards>(entity =>
            {
                entity.HasKey(x => x.IdCustomer)
                    .HasName("PK__tbl_card__DB43864A0D17DC50");

                entity.ToTable("tbl_cards");

                entity.HasIndex(x => x.IdCard)
                    .HasName("UQ__tbl_card__3B7B33C36806A437")
                    .IsUnique();

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCard)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.CardStatusNavigation)
                    .WithMany(p => p.TblCards)
                    .HasForeignKey(x => x.CardStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_cards__CardS__534D60F1");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithOne(p => p.TblCards)
                    .HasForeignKey<TblCards>(x => x.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_cards__IdCus__5441852A");

                entity.HasOne(d => d.InsertByNavigation)
                    .WithMany(p => p.TblCardsInsertByNavigation)
                    .HasForeignKey(x => x.InsertBy)
                    .HasConstraintName("FK__tbl_cards__Inser__5535A963");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.TblCardsUpdateByNavigation)
                    .HasForeignKey(x => x.UpdateBy)
                    .HasConstraintName("FK__tbl_cards__Updat__5629CD9C");
            });

            modelBuilder.Entity<TblCustomerAddress>(entity =>
            {
                entity.HasKey(x => new { x.IdCustomer, x.IdAddress })
                    .HasName("PK__tbl_cust__345F797DF6DF9B1E");

                entity.ToTable("tbl_customer_address");

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.TblCustomerAddress)
                    .HasForeignKey(x => x.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__IdAdd__571DF1D5");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.TblCustomerAddress)
                    .HasForeignKey(x => x.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__IdCus__5812160E");
            });

            modelBuilder.Entity<TblCustomerDiscount>(entity =>
            {
                entity.HasKey(x => new { x.IdCustomer, x.IdDiscount })
                    .HasName("PK__tbl_cust__E72988E91CA42399");

                entity.ToTable("tbl_customer_discount");

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeForActive)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.TblCustomerDiscount)
                    .HasForeignKey(x => x.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__IdCus__5AEE82B9");

                entity.HasOne(d => d.IdDiscountNavigation)
                    .WithMany(p => p.TblCustomerDiscount)
                    .HasForeignKey(x => x.IdDiscount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__IdDis__5BE2A6F2");

                entity.HasOne(d => d.InsertByNavigation)
                    .WithMany(p => p.TblCustomerDiscount)
                    .HasForeignKey(x => x.InsertBy)
                    .HasConstraintName("FK__tbl_custo__Inser__5CD6CB2B");
            });

            modelBuilder.Entity<TblCustomerLogs>(entity =>
            {
                entity.HasKey(x => x.Pid);

                entity.ToTable("tbl_customer_logs");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.CustomerXml)
                    .IsRequired()
                    .HasColumnName("CustomerXML")
                    .HasColumnType("xml");

                entity.Property(e => e.IdCustomer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTool)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.TblCustomerLogs)
                    .HasForeignKey(x => x.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__IdCus__5DCAEF64");

                entity.HasOne(d => d.IdToolNavigation)
                    .WithMany(p => p.TblCustomerLogs)
                    .HasForeignKey(x => x.IdTool)
                    .HasConstraintName("FK__tbl_custo__IdToo__5EBF139D");
            });

            modelBuilder.Entity<TblCustomerStatus>(entity =>
            {
                entity.HasKey(x => x.IdCustomerStatus);

                entity.ToTable("tbl_customer_status");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerType>(entity =>
            {
                entity.HasKey(x => x.IdCustomerType);

                entity.ToTable("tbl_customer_type");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomers>(entity =>
            {
                entity.HasKey(x => x.IdCustomer);

                entity.ToTable("tbl_customers");

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pec)
                    .HasColumnName("PEC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sdi)
                    .HasColumnName("SDI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerStatusNavigation)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(x => x.CustomerStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__Custo__656C112C");

                entity.HasOne(d => d.CustomerTypeNavigation)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(x => x.CustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_custo__Custo__6477ECF3");

                entity.HasOne(d => d.IdDiscountNavigation)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(x => x.IdDiscount)
                    .HasConstraintName("FK__tbl_custo__IdDis__66603565");

                entity.HasOne(d => d.InsertByNavigation)
                    .WithMany(p => p.TblCustomersInsertByNavigation)
                    .HasForeignKey(x => x.InsertBy)
                    .HasConstraintName("FK__tbl_custo__Inser__6754599E");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.TblCustomersUpdateByNavigation)
                    .HasForeignKey(x => x.UpdateBy)
                    .HasConstraintName("FK__tbl_custo__Updat__68487DD7");
            });

            modelBuilder.Entity<TblDiscountType>(entity =>
            {
                entity.HasKey(x => x.IdDiscountType);

                entity.ToTable("tbl_discount_type");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountTypeTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblDiscounts>(entity =>
            {
                entity.HasKey(x => x.IdDiscount);

                entity.ToTable("tbl_discounts");

                entity.Property(e => e.DiscountDescription)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountEndDate).HasColumnType("date");

                entity.Property(e => e.DiscountStartDate).HasColumnType("date");

                entity.Property(e => e.DiscountTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblProductDiscount>(entity =>
            {
                entity.HasKey(x => new { x.IdProduct, x.IdDiscount })
                    .HasName("PK__tbl_prod__12E34877515424DE");

                entity.ToTable("tbl_product_discount");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeForActive)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdDiscountNavigation)
                    .WithMany(p => p.TblProductDiscount)
                    .HasForeignKey(x => x.IdDiscount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_produ__IdDis__70DDC3D8");
            });

            modelBuilder.Entity<TblProducts>(entity =>
            {
                entity.HasKey(x => x.IdProduct);

                entity.ToTable("tbl_products");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertData).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblProfilePermission>(entity =>
            {
                entity.HasKey(x => x.ProfileSetName)
                    .HasName("PK__tbl_prof__ABF29A3536E55662");

                entity.ToTable("tbl_profile_permission");

                entity.Property(e => e.ProfileSetName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileCode)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.TblProfilePermission)
                    .HasForeignKey(x => x.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_profi__IdPro__75A278F5");
            });

            modelBuilder.Entity<TblShipments>(entity =>
            {
                entity.HasKey(x => x.Pid);

                entity.ToTable("tbl_shipments");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Awb).HasColumnName("AWB");

                entity.Property(e => e.DatetimeCreation).HasColumnType("datetime");

                entity.Property(e => e.IdCostumer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTool)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.TblShipments)
                    .HasForeignKey(x => x.IdCostumer)
                    .HasConstraintName("FK__tbl_shipm__IdCos__76969D2E");

                entity.HasOne(d => d.IdToolNavigation)
                    .WithMany(p => p.TblShipments)
                    .HasForeignKey(x => x.IdTool)
                    .HasConstraintName("FK__tbl_shipm__IdToo__778AC167");
            });

            modelBuilder.Entity<TblToolPermission>(entity =>
            {
                entity.HasKey(x => x.IdProfile)
                    .HasName("PK__tbl_tool__120435C168B50901");

                entity.ToTable("tbl_tool_permission");

                entity.Property(e => e.ProfileCode)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTools>(entity =>
            {
                entity.HasKey(x => x.IdTool);

                entity.ToTable("tbl_tools");

                entity.Property(e => e.IdTool)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToolKey)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.ToolName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.TblTools)
                    .HasForeignKey(x => x.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_tools__IdPro__7A672E12");
            });

            modelBuilder.Entity<TblTransactionLogs>(entity =>
            {
                entity.HasKey(x => x.Pid);

                entity.ToTable("tbl_transaction_logs");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Awb).HasColumnName("AWB");

                entity.Property(e => e.Awbstatus).HasColumnName("AWBStatus");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCustomer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTool)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("TransactionID")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCardNavigation)
                    .WithMany(p => p.TblTransactionLogs)
                    .HasPrincipalKey(x => x.IdCard)
                    .HasForeignKey(x => x.IdCard)
                    .HasConstraintName("FK__tbl_trans__IdCar__7B5B524B");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.TblTransactionLogs)
                    .HasForeignKey(x => x.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_trans__IdCus__7C4F7684");

                entity.HasOne(d => d.IdToolNavigation)
                    .WithMany(p => p.TblTransactionLogs)
                    .HasForeignKey(x => x.IdTool)
                    .HasConstraintName("FK__tbl_trans__IdToo__7D439ABD");

                entity.HasOne(d => d.InsertByNavigation)
                    .WithMany(p => p.TblTransactionLogs)
                    .HasForeignKey(x => x.InsertBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_trans__Inser__7E37BEF6");
            });

            modelBuilder.Entity<TblUserType>(entity =>
            {
                entity.HasKey(x => x.IdUserType);

                entity.ToTable("tbl_user_type");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserTypeTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(x => x.IdUser);

                entity.ToTable("tbl_users");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TitleOfCourtesy)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(x => x.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_users__UserT__7F2BE32F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
