﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieDemo.GetMovieService.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoMovie_DBEntities : DbContext
    {
        public DemoMovie_DBEntities()
            : base("name=DemoMovie_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCategory> MovieCategory { get; set; }
        public virtual DbSet<MovieComment> MovieComment { get; set; }
        public virtual DbSet<MovieOffer> MovieOffer { get; set; }
        public virtual DbSet<MovieRate> MovieRate { get; set; }
        public virtual DbSet<MovieScore> MovieScore { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}