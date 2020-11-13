using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoadCalculModel;
using Microsoft.Extensions.Configuration;

namespace ReadCalculRepository
{
    public class DBModelContext : DbContext
    {
        public DbSet<RoadCalculModel.DataBase.CalculDistanceHistorique> CalculDistanceHistoriques { get; set; }
        public DbSet<RoadCalculModel.DataBase.SearchHistorique> SearchHistoriques { get; set; }
        //public DbSet<Post> Posts { get; set; }

        public DBModelContext(
             DbContextOptions<DBModelContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoadCalculModel.DataBase.CalculDistanceHistorique>(entity =>
            {
                entity.ToTable("CalculDistanceHistorique", "dbo");
                entity.Property(e => e.ID).HasColumnName("ID").UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(e => e.Time).HasColumnName("Time");
                entity.Property(e => e.OriginLat).HasColumnName("OriginLat");
                entity.Property(e => e.OriginLong).HasColumnName("OriginLong");
                entity.Property(e => e.DestinationLat).HasColumnName("DestinationLat");
                entity.Property(e => e.DestinationLong).HasColumnName("DestinationLong");
                entity.Property(e => e.DestinationName).HasColumnName("DestinationName");
                entity.Property(e => e.DestinationType).HasColumnName("DestinationType");
                entity.Property(e => e.OriginName).HasColumnName("OriginName");
                entity.Property(e => e.OriginType).HasColumnName("OriginType");
                entity.Property(e => e.CarConsumption).HasColumnName("CarCosumption");
            });

            modelBuilder.Entity<RoadCalculModel.DataBase.SearchHistorique>(entity =>
            {
                entity.ToTable("SearchHistorique", "dbo");
                entity.Property(e => e.ID).HasColumnName("ID").UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(e => e.Time).HasColumnName("Time");
                entity.Property(e => e.Querry).HasColumnName("Querry");
            });
        }
    }
}
