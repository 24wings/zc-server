using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wings.Base.RBAC.Entity;

namespace Wings.DataAccess {
    public partial class WingsContext : DbContext {
        public WingsContext () { }

        public WingsContext (DbContextOptions<WingsContext> options) : base (options) { }

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

        }
    }
}