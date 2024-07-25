using HospitalApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace HospitalApp.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalApp;Uid=sa;Pwd=aysu123;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
           .Ignore(e => e.ImageUrl);


            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hospital)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Department>()
                .HasOne(d => d.Hospital)
                .WithMany(h => h.Departments)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Hospital)
                .WithMany(h => h.Contacts)
                .HasForeignKey(c => c.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.DoctorAppointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.PatientAppointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Appointments)
                .WithOne()
                .HasForeignKey("DoctorId")
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Appointment>()
                    .HasOne(a => a.Doctor)
                    .WithMany(u => u.DoctorAppointments)
                    .HasForeignKey(a => a.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.PatientAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Hospital)
                .WithMany(h => h.Appointments)
                .HasForeignKey(a => a.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

        }
         
            public DbSet<ApplicationUser> ApplicationUsers { get; set; }

            public DbSet<Room> Rooms { get; set; }

            public DbSet<HospitalInfo> HospitalInfos { get; set; }

            public DbSet<Department> Departments { get; set; }

            public DbSet<Contact> Contacts { get; set; }

            public DbSet<Appointment> Appointments { get; set; }    
            
        }

    }
    