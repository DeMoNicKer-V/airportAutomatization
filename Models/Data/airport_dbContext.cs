using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace airportAutomatization
{
    public partial class airport_dbContext : DbContext
    {
        public airport_dbContext()
        {
        }

        public airport_dbContext(DbContextOptions<airport_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aircraft> Aircraft { get; set; } = null!;
        public virtual DbSet<Aircrew> Aircrews { get; set; } = null!;
        public virtual DbSet<Cashier> Cashiers { get; set; } = null!;
        public virtual DbSet<Copilot> Copilots { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Pilot> Pilots { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=VIKTOR-LENOVO-G;Database=airport_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.ToTable("aircraft");

                entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model_name");

                entity.HasOne(d => d.ModelNameNavigation)
                    .WithMany(p => p.Aircraft)
                    .HasForeignKey(d => d.ModelName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("is_model_name");
            });

            modelBuilder.Entity<Aircrew>(entity =>
            {
                entity.ToTable("aircrew");

                entity.Property(e => e.AircrewId).HasColumnName("aircrew_id");

                entity.Property(e => e.AdmissionGroup).HasColumnName("admission_group");

                entity.Property(e => e.CopilotId).HasColumnName("copilot_id");

                entity.Property(e => e.PilotId).HasColumnName("pilot_id");

                entity.HasOne(d => d.Copilot)
                    .WithMany(p => p.Aircrews)
                    .HasForeignKey(d => d.CopilotId)
                    .HasConstraintName("in_copilot_id");

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.Aircrews)
                    .HasForeignKey(d => d.PilotId)
                    .HasConstraintName("in_pilot_id");
            });

            modelBuilder.Entity<Cashier>(entity =>
            {
                entity.ToTable("cashier");

                entity.Property(e => e.CashierId).HasColumnName("cashier_id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("full_name");
            });

            modelBuilder.Entity<Copilot>(entity =>
            {
                entity.ToTable("copilot");

                entity.Property(e => e.CopilotId).HasColumnName("copilot_id");

                entity.Property(e => e.AdmissionGroup).HasColumnName("admission_group");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.NumberOfFlights).HasColumnName("number_of_flights");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");

                entity.Property(e => e.AircrewId).HasColumnName("aircrew_id");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("arrival_date");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasColumnName("departure_date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("destination");

                entity.HasOne(d => d.Aircraft)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AircraftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("on_aircraft_id");

                entity.HasOne(d => d.Aircrew)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AircrewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("on_aircrew_id");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelName)
                    .HasName("XPKmodel");

                entity.ToTable("model");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model_name");

                entity.Property(e => e.AdmissionGroup).HasColumnName("admission_group");

                entity.Property(e => e.Fuel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fuel");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.NumberOfSeats).HasColumnName("number_of_seats");

                entity.Property(e => e.RunLength).HasColumnName("run_length");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TakeoffWeight).HasColumnName("takeoff_weight");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("passenger");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("full_name");
            });

            modelBuilder.Entity<Pilot>(entity =>
            {
                entity.ToTable("pilot");

                entity.Property(e => e.PilotId).HasColumnName("pilot_id");

                entity.Property(e => e.AdmissionGroup).HasColumnName("admission_group");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.NumberOfFlights).HasColumnName("number_of_flights");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.CashierId).HasColumnName("cashier_id");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.Price)
                    .HasColumnType("smallmoney")
                    .HasColumnName("price");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("sold");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("is_on_flight_id");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("bought");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
