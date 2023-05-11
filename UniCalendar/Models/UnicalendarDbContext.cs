using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniCalendar.Models;

public partial class UnicalendarDbContext : DbContext
{
    public UnicalendarDbContext()
    {
    }

    public UnicalendarDbContext(DbContextOptions<UnicalendarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Modulecategory> Modulecategories { get; set; }

    public virtual DbSet<Parentcategory> Parentcategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.ParentCategoryId, "idParentCategory_idx");

            entity.Property(e => e.IdCategory)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idCategory");
            entity.Property(e => e.CategoryName).HasMaxLength(200);
            entity.Property(e => e.ParentCategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("ParentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.Categories)
                .HasForeignKey(d => d.ParentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idParentCategory");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.GoogleCalendarId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("event");

            entity.HasIndex(e => e.Idlecturer, "fkLecturer_idx");

            entity.HasIndex(e => e.Idmodule, "fkModule_idx");

            entity.Property(e => e.EventId).HasColumnType("int(11)");
            entity.Property(e => e.GoogleCalendarId)
                .HasColumnType("int(11)")
                .HasColumnName("GoogleCalendarID");
            entity.Property(e => e.EventName).HasMaxLength(250);
            entity.Property(e => e.Eventdetails).HasColumnType("mediumtext");
            entity.Property(e => e.Idlecturer)
                .HasColumnType("int(11)")
                .HasColumnName("idlecturer");
            entity.Property(e => e.Idmodule)
                .HasColumnType("int(11)")
                .HasColumnName("idmodule");

            entity.HasOne(d => d.IdlecturerNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Idlecturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkLecturer");

            entity.HasOne(d => d.IdmoduleNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Idmodule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkModule");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.IdInterest).HasName("PRIMARY");

            entity.ToTable("interest");

            entity.Property(e => e.IdInterest)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idInterest");
            entity.Property(e => e.Comment).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.EventId)
                .HasColumnType("int(11)")
                .HasColumnName("EventID");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(11)")
                .HasColumnName("ModuleID");
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.IdLecturer).HasName("PRIMARY");

            entity.ToTable("lecturer");

            entity.Property(e => e.IdLecturer)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idLecturer");
            entity.Property(e => e.LecturerBio).HasColumnType("mediumtext");
            entity.Property(e => e.LecturerEmail).HasMaxLength(60);
            entity.Property(e => e.LecturerName).HasMaxLength(45);
            entity.Property(e => e.LecturerPhoto).HasColumnType("blob");
            entity.Property(e => e.LecturerRoles).HasMaxLength(255);
            entity.Property(e => e.LecturerUrl)
                .HasMaxLength(255)
                .HasColumnName("LecturerURL");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.IdModules).HasName("PRIMARY");

            entity.ToTable("modules");

            entity.HasIndex(e => e.ModuleLeader, "ModuleLeader_idx");

            entity.HasIndex(e => e.IdModules, "idModules_UNIQUE").IsUnique();

            entity.Property(e => e.IdModules)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idModules");
            entity.Property(e => e.Active).HasMaxLength(10);
            entity.Property(e => e.Book).HasMaxLength(10);
            entity.Property(e => e.GoogleCalendarId)
                .HasMaxLength(40)
                .HasColumnName("GoogleCalendarID");
            entity.Property(e => e.GoogleCalendarTitle).HasMaxLength(200);
            entity.Property(e => e.Lab).HasMaxLength(10);
            entity.Property(e => e.Lectures).HasColumnType("int(11)");
            entity.Property(e => e.ModuleDesc).HasColumnType("mediumtext");
            entity.Property(e => e.ModuleFacebookGroup).HasMaxLength(200);
            entity.Property(e => e.ModuleLeader).HasColumnType("int(11)");
            entity.Property(e => e.ModuleName).HasMaxLength(250);
            entity.Property(e => e.ModuleType).HasMaxLength(45);
            entity.Property(e => e.ModuleUrl)
                .HasMaxLength(200)
                .HasColumnName("ModuleURL");
            entity.Property(e => e.ModuleVideoUrl)
                .HasMaxLength(200)
                .HasColumnName("ModuleVideoURL");
            entity.Property(e => e.Online).HasMaxLength(10);
            entity.Property(e => e.OnlineMethod).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.Rating).HasColumnType("int(11)");
            entity.Property(e => e.Room).HasMaxLength(45);
            entity.Property(e => e.Tags).HasMaxLength(100);
            entity.Property(e => e.TotalHours).HasColumnType("int(11)");

            entity.HasOne(d => d.ModuleLeaderNavigation).WithMany(p => p.Modules)
                .HasForeignKey(d => d.ModuleLeader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ModuleLeader");
        });

        modelBuilder.Entity<Modulecategory>(entity =>
        {
            entity.HasKey(e => new { e.IdModule, e.IdCategory })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("modulecategories");

            entity.HasIndex(e => e.IdCategory, "categories_idx");

            entity.Property(e => e.IdModule)
                .HasColumnType("int(11)")
                .HasColumnName("idModule");
            entity.Property(e => e.IdCategory).HasColumnType("int(11)");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Modulecategories)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categories");

            entity.HasOne(d => d.IdModuleNavigation).WithMany(p => p.Modulecategories)
                .HasForeignKey(d => d.IdModule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Modules");
        });

        modelBuilder.Entity<Parentcategory>(entity =>
        {
            entity.HasKey(e => e.IdParentCategory).HasName("PRIMARY");

            entity.ToTable("parentcategory");

            entity.Property(e => e.IdParentCategory)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idParentCategory");
            entity.Property(e => e.ParentCategoryName)
                .HasMaxLength(200)
                .HasColumnName("parentCategoryName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
