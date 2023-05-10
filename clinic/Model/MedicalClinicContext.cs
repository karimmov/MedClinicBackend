using System;
using System.Collections.Generic;
using clinic.Model.Tables;
using Microsoft.EntityFrameworkCore;

namespace clinic.Model;

public partial class MedicalClinicContext : DbContext
{
    public MedicalClinicContext()
    {
    }

    public MedicalClinicContext(DbContextOptions<MedicalClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analysiscategory> Analysiscategories { get; set; }

    public virtual DbSet<Analysispopularuty> Analysispopularuties { get; set; }

    public virtual DbSet<Analysisresult> Analysisresults { get; set; }

    public virtual DbSet<Analysistype> Analysistypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=medical-clinic;Username=postgres;Password=LIRESU42;Include Error Detail=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("requeststatus", new[] { "Выполняется", "Результаты готовы", "Ожидается посещение" });


        modelBuilder.Entity<Analysiscategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("analysiscategory_pkey");

            entity.ToTable("analysiscategory");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname).HasColumnName("categoryname");
        });

        modelBuilder.Entity<Analysispopularuty>(entity =>
        {
            entity.HasKey(e => e.Analysispopularityid).HasName("analysispopularuty_pkey");

            entity.ToTable("analysispopularuty");

            entity.Property(e => e.Analysispopularityid).HasColumnName("analysispopularityid");
            entity.Property(e => e.Analysisname).HasColumnName("analysisname");
            entity.Property(e => e.Purchasescount).HasColumnName("purchasescount");

            entity.HasOne(d => d.AnalysisnameNavigation).WithMany(p => p.Analysispopularuties)
                .HasForeignKey(d => d.Analysisname)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysispopularuty_analysisname_fkey");
        });

        modelBuilder.Entity<Analysisresult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("analysisresult_pkey");

            entity.ToTable("analysisresult");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Analysisresult1).HasColumnName("analysisresult");
            entity.Property(e => e.Analysistype).HasColumnName("analysistype");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Ожидается посещение'::requeststatus")
                .HasColumnName("status");

            entity.HasOne(d => d.AnalysistypeNavigation).WithMany(p => p.Analysisresults)
                .HasForeignKey(d => d.Analysistype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysisresult_analysistype_fkey");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Analysisresults)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysisresult_client_fkey");

            entity.HasOne(d => d.OfficeNavigation).WithMany(p => p.Analysisresults)
                .HasForeignKey(d => d.Office)
                .HasConstraintName("analysisresult_office_fkey");
        });

        modelBuilder.Entity<Analysistype>(entity =>
        {
            entity.HasKey(e => e.Analysisid).HasName("analysistypes_pkey");

            entity.ToTable("analysistypes");

            entity.Property(e => e.Analysisid).HasColumnName("analysisid");
            entity.Property(e => e.Analysistitle).HasColumnName("analysistitle");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Duration)
                .HasMaxLength(10)
                .HasColumnName("duration");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Analysistypes)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysistypes_category_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Phonenumber, "clients_phonenumber_key").IsUnique();

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.BirthDate).HasDefaultValueSql("'-infinity'::date");
            entity.Property(e => e.Clientname)
                .HasMaxLength(70)
                .HasColumnName("clientname");
            entity.Property(e => e.Email).HasDefaultValueSql("''::text");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(100)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(11)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Officeid).HasName("offices_pkey");

            entity.ToTable("offices");

            entity.Property(e => e.Officeid).HasColumnName("officeid");
            entity.Property(e => e.Officeaddress)
                .HasMaxLength(200)
                .HasColumnName("officeaddress");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
