using DemoMovie.Core;
using Microsoft.EntityFrameworkCore;
using DemoMovie.Repository.Configurations;
using System.Reflection;

namespace DemoMovie.Repository
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<MovieCategory> MovieCategory{ get; set; }
        public DbSet<MovieComment> MovieComment { get; set; }
        public DbSet<Movies> Movie { get; set; }
        public DbSet<MovieScore> MovieScore { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<MovieOffer> MovieOffer { get; set; }
        public DbSet<MovieRate> MovieRate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//IEntityTypeConfiguration ın kalıtım verdiği bütün classlara uygular bu da bütün tablolar için configuration işlemleri yapar anlamına gelmektedir.


            //modelBuilder.ApplyConfiguration(new MovieConfiguration());//her bir oluşturulan tablo configuration için de bu şekilde bir yükleme yapılabilir ama çok fazla tablo olduğunu düşünürsek bu işlem çok fazla zahmetli olacaktır

            //modelBuilder.ApplyConfiguration(new MovieCategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new MovieCommentConfiguration());
            //modelBuilder.ApplyConfiguration(new MovieScoreConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
