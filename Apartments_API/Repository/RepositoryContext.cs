using Apartments_API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options, IMapper mapper)
            : base(options)
        {
            Mapper = mapper;
        }

        public readonly IMapper Mapper;
        public virtual DbSet<Butas> Butas { get; set; }
        public virtual DbSet<ButoBusena> ButoBusena { get; set; }
        public virtual DbSet<ButoLaikotarpioBusena> ButoLaikotarpioBusena { get; set; }
        public virtual DbSet<Darbas> Darbas { get; set; }
        public virtual DbSet<DarboBusena> DarboBusena { get; set; }
        public virtual DbSet<IsNaudotojas> IsNaudotojas { get; set; }
        public virtual DbSet<Mokejimas> Mokejimas { get; set; }
        public virtual DbSet<Nuomininkas> Nuomininkas { get; set; }
        public virtual DbSet<NuomosLaikotarpis> NuomosLaikotarpis { get; set; }
        public virtual DbSet<Privalumas> Privalumas { get; set; }
        public virtual DbSet<Reitingas> Reitingas { get; set; }
        public virtual DbSet<Savininkas> Savininkas { get; set; }
        public virtual DbSet<Skundas> Skundas { get; set; }
        public virtual DbSet<Valytojas> Valytojas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseMySql("server=localhost;database=apartments;user=root;pwd=;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Butas>(entity =>
            {
                entity.HasKey(e => e.IdButas)
                    .HasName("PRIMARY");

                entity.ToTable("butas");

                entity.HasIndex(e => e.Busena)
                    .HasName("busena");

                entity.HasIndex(e => e.FkSavininkasidIsNaudotojas)
                    .HasName("turi");

                entity.Property(e => e.IdButas)
                    .HasColumnName("id_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adresas)
                    .HasColumnName("adresas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.Aprašas)
                    .HasColumnName("aprašas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dydis)
                    .HasColumnName("dydis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSavininkasidIsNaudotojas)
                    .HasColumnName("fk_savininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KainaUzNakti)
                    .HasColumnName("kaina_uz_nakti")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KambaruSkaicius)
                    .HasColumnName("kambaru_skaicius")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Miestas)
                    .HasColumnName("miestas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.NuotraukaUrl)
                    .HasColumnName("nuotraukaURL")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.PridejimoData)
                    .HasColumnName("pridejimo_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Šalis)
                    .HasColumnName("šalis")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.HasOne(d => d.BusenaNavigation)
                    .WithMany(p => p.Butas)
                    .HasForeignKey(d => d.Busena)
                    .HasConstraintName("butas_ibfk_1");

                entity.HasOne(d => d.FkSavininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.Butas)
                    .HasForeignKey(d => d.FkSavininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");
            });

            modelBuilder.Entity<ButoBusena>(entity =>
            {
                entity.HasKey(e => e.IdButoBusena)
                    .HasName("PRIMARY");

                entity.ToTable("buto_busena");

                entity.Property(e => e.IdButoBusena)
                    .HasColumnName("id_buto_busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("char(10)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);
            });

            modelBuilder.Entity<ButoLaikotarpioBusena>(entity =>
            {
                entity.HasKey(e => e.IdButoLaikotarpioBusena)
                    .HasName("PRIMARY");

                entity.ToTable("buto_laikotarpio_busena");

                entity.Property(e => e.IdButoLaikotarpioBusena)
                    .HasColumnName("id_buto_laikotarpio_busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("char(10)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);
            });

            modelBuilder.Entity<Darbas>(entity =>
            {
                entity.HasKey(e => e.IdDarbas)
                    .HasName("PRIMARY");

                entity.ToTable("darbas");

                entity.HasIndex(e => e.Busena)
                    .HasName("busena");

                entity.HasIndex(e => e.FkButasidButas)
                    .HasName("priklauso");

                entity.HasIndex(e => e.FkSavininkasidIsNaudotojas)
                    .HasName("paskelbia");

                entity.HasIndex(e => e.FkValytojasidIsNaudotojas)
                    .HasName("priima");

                entity.Property(e => e.IdDarbas)
                    .HasColumnName("id_darbas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkButasidButas)
                    .HasColumnName("fk_butasid_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSavininkasidIsNaudotojas)
                    .HasColumnName("fk_savininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkValytojasidIsNaudotojas)
                    .HasColumnName("fk_valytojasid_is_naudotojas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IvykdymoData)
                    .HasColumnName("ivykdymo_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SukurimoData)
                    .HasColumnName("sukurimo_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Uzmokestis)
                    .HasColumnName("uzmokestis")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DarboBusena)
                    .WithMany(p => p.Darbas)
                    .HasForeignKey(d => d.Busena)
                    .HasConstraintName("darbas_ibfk_1");

                entity.HasOne(d => d.FkButasidButasNavigation)
                    .WithMany(p => p.Darbas)
                    .HasForeignKey(d => d.FkButasidButas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso");

                entity.HasOne(d => d.FkSavininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.Darbas)
                    .HasForeignKey(d => d.FkSavininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paskelbia");

                entity.HasOne(d => d.FkValytojasidIsNaudotojasNavigation)
                    .WithMany(p => p.Darbas)
                    .HasForeignKey(d => d.FkValytojasidIsNaudotojas)
                    .HasConstraintName("priima");
            });

            modelBuilder.Entity<DarboBusena>(entity =>
            {
                entity.HasKey(e => e.IdDarboBusena)
                    .HasName("PRIMARY");

                entity.ToTable("darbo_busena");

                entity.Property(e => e.IdDarboBusena)
                    .HasColumnName("id_darbo_busena")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("char(10)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);
            });

            modelBuilder.Entity<IsNaudotojas>(entity =>
            {
                entity.HasKey(e => e.IdIsNaudotojas)
                    .HasName("PRIMARY");

                entity.ToTable("is_naudotojas");

                entity.Property(e => e.IdIsNaudotojas)
                    .HasColumnName("id_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Balansas)
                    .HasColumnName("balansas")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ElPastas)
                    .HasColumnName("el_pastas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.PaskutinisPrisijungimas)
                    .HasColumnName("paskutinis_prisijungimas")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Pavarde)
                    .HasColumnName("pavarde")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.RegistracijosData)
                    .HasColumnName("registracijos_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Slaptazodis)
                    .HasColumnName("slaptazodis")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);
            });

            modelBuilder.Entity<Mokejimas>(entity =>
            {
                entity.HasKey(e => e.IdMokejimas)
                    .HasName("PRIMARY");

                entity.ToTable("mokejimas");

                entity.HasIndex(e => e.FkNuomininkasidIsNaudotojas)
                    .HasName("atlieka");

                entity.Property(e => e.IdMokejimas)
                    .HasColumnName("id_mokejimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkNuomininkasidIsNaudotojas)
                    .HasColumnName("fk_nuomininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Suma)
                    .HasColumnName("suma")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkNuomininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.Mokejimas)
                    .HasForeignKey(d => d.FkNuomininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atlieka");
            });

            modelBuilder.Entity<Nuomininkas>(entity =>
            {
                entity.HasKey(e => e.IdIsNaudotojas)
                    .HasName("PRIMARY");

                entity.ToTable("nuomininkas");

                entity.Property(e => e.IdIsNaudotojas)
                    .HasColumnName("id_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdIsNaudotojasNavigation)
                    .WithOne(p => p.Nuomininkas)
                    .HasForeignKey<Nuomininkas>(d => d.IdIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nuomininkas_ibfk_1");
            });

            modelBuilder.Entity<NuomosLaikotarpis>(entity =>
            {
                entity.HasKey(e => e.IdNuomosLaikotarpis)
                    .HasName("PRIMARY");

                entity.ToTable("nuomos_laikotarpis");

                entity.HasIndex(e => e.Busena)
                    .HasName("busena");

                entity.HasIndex(e => e.FkButasidButas)
                    .HasName("yra_nuomojamas");

                entity.HasIndex(e => e.FkNuomininkasidIsNaudotojas)
                    .HasName("nuomoja");

                entity.Property(e => e.IdNuomosLaikotarpis)
                    .HasColumnName("id_nuomos_laikotarpis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Busena)
                    .HasColumnName("busena")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkButasidButas)
                    .HasColumnName("fk_butasid_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNuomininkasidIsNaudotojas)
                    .HasColumnName("fk_nuomininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Iki)
                    .HasColumnName("iki")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nuo)
                    .HasColumnName("nuo")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.BusenaNavigation)
                    .WithMany(p => p.NuomosLaikotarpis)
                    .HasForeignKey(d => d.Busena)
                    .HasConstraintName("nuomos_laikotarpis_ibfk_1");

                entity.HasOne(d => d.FkButasidButasNavigation)
                    .WithMany(p => p.NuomosLaikotarpis)
                    .HasForeignKey(d => d.FkButasidButas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra_nuomojamas");

                entity.HasOne(d => d.FkNuomininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.NuomosLaikotarpis)
                    .HasForeignKey(d => d.FkNuomininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nuomoja");
            });

            modelBuilder.Entity<Privalumas>(entity =>
            {
                entity.HasKey(e => e.IdPrivalumas)
                    .HasName("PRIMARY");

                entity.ToTable("privalumas");

                entity.HasIndex(e => e.FkButasidButas)
                    .HasName("turi2");

                entity.Property(e => e.IdPrivalumas)
                    .HasColumnName("id_privalumas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkButasidButas)
                    .HasColumnName("fk_butasid_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.HasOne(d => d.FkButasidButasNavigation)
                    .WithMany(p => p.Privalumas)
                    .HasForeignKey(d => d.FkButasidButas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi2");
            });

            modelBuilder.Entity<Reitingas>(entity =>
            {
                entity.HasKey(e => e.IdReitingas)
                    .HasName("PRIMARY");

                entity.ToTable("reitingas");

                entity.HasIndex(e => e.FkButasidButas)
                    .HasName("skiriamas2");

                entity.HasIndex(e => e.FkNuomininkasidIsNaudotojas)
                    .HasName("pateikia2");

                entity.Property(e => e.IdReitingas)
                    .HasColumnName("id_reitingas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkButasidButas)
                    .HasColumnName("fk_butasid_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNuomininkasidIsNaudotojas)
                    .HasColumnName("fk_nuomininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ivertinimas)
                    .HasColumnName("ivertinimas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkButasidButasNavigation)
                    .WithMany(p => p.Reitingas)
                    .HasForeignKey(d => d.FkButasidButas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skiriamas2");

                entity.HasOne(d => d.FkNuomininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.Reitingas)
                    .HasForeignKey(d => d.FkNuomininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pateikia2");
            });

            modelBuilder.Entity<Savininkas>(entity =>
            {
                entity.HasKey(e => e.IdIsNaudotojas)
                    .HasName("PRIMARY");

                entity.ToTable("savininkas");

                entity.Property(e => e.IdIsNaudotojas)
                    .HasColumnName("id_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdIsNaudotojasNavigation)
                    .WithOne(p => p.Savininkas)
                    .HasForeignKey<Savininkas>(d => d.IdIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("savininkas_ibfk_1");
            });

            modelBuilder.Entity<Skundas>(entity =>
            {
                entity.HasKey(e => e.IdSkundas)
                    .HasName("PRIMARY");

                entity.ToTable("skundas");

                entity.HasIndex(e => e.FkButasidButas)
                    .HasName("skiriamas");

                entity.HasIndex(e => e.FkNuomininkasidIsNaudotojas)
                    .HasName("pateikia");

                entity.Property(e => e.IdSkundas)
                    .HasColumnName("id_skundas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkButasidButas)
                    .HasColumnName("fk_butasid_butas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNuomininkasidIsNaudotojas)
                    .HasColumnName("fk_nuomininkasid_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pranesimas)
                    .HasColumnName("pranesimas")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'NULL'")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8);

                entity.HasOne(d => d.FkButasidButasNavigation)
                    .WithMany(p => p.Skundas)
                    .HasForeignKey(d => d.FkButasidButas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skiriamas");

                entity.HasOne(d => d.FkNuomininkasidIsNaudotojasNavigation)
                    .WithMany(p => p.Skundas)
                    .HasForeignKey(d => d.FkNuomininkasidIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pateikia");
            });

            modelBuilder.Entity<Valytojas>(entity =>
            {
                entity.HasKey(e => e.IdIsNaudotojas)
                    .HasName("PRIMARY");

                entity.ToTable("valytojas");

                entity.Property(e => e.IdIsNaudotojas)
                    .HasColumnName("id_is_naudotojas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdIsNaudotojasNavigation)
                    .WithOne(p => p.Valytojas)
                    .HasForeignKey<Valytojas>(d => d.IdIsNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("valytojas_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
