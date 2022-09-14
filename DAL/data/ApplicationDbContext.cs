using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL.data

{
    public class ApplicationDbContext : DbContext
    {
        // La connection string 
        private readonly string _cnstr;

        // Un constreur pour la dal qui récupère la connection string.
        // cnt string pour la migration =/= appsetting.json

        // CAUTION : when in appdbcontext dal the connection string can be only  \  but in the API it must be \\ (double slahs)
        public ApplicationDbContext() 
        {
            this._cnstr = @"Data Source=SQL8004.site4now.net;Initial Catalog=db_a8b35d_majescticboydb;User Id=db_a8b35d_majescticboydb_admin;Password=Host@6572;";

            // Smarterasp connectionstring
           // this._cnstr = @"Data Source=SQL8004.site4now.net;Initial Catalog=db_a8b35d_majescticboydb;User Id=db_a8b35d_majescticboydb_admin;Password=YOUR_DB_PASSWORD";
        }

        // un second constructeur qui va aller communiquer avec l'application.
        // La string


        public ApplicationDbContext(string connectionString) : base()
        {
            this._cnstr = connectionString;
        }

        // Injecter dans l'option builder
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_cnstr);
        }

        // Seed la db lors de la creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModelDal>().HasData(
                new CustomerModelDal { id_customer = 1, name = "obiwan", vat = "68793", adress = "rue de Tatoinne", email = "obi@gmail.com", phoneNumber = "045823232" },
                new CustomerModelDal { id_customer = 2, name = "anaki", vat = "943249", adress = "rue de Coruscant", email = "anakin@gmail.com", phoneNumber = "04598382832" }
            );

            modelBuilder.Entity<DeliveryModelDal>().HasData(
                new DeliveryModelDal { id_delivery = 1, numeroDelivery = "ZIH313213", weight = 968, adress = "Rue des amazon", dateTransfert = new DateTime(2022, 05, 15), dateDelivery = new DateTime(2022, 05, 30), remarks = "have the customs" },
                new DeliveryModelDal { id_delivery = 2, numeroDelivery = "FEDEX02133", weight = 563, adress = "Rue des BPOST", dateTransfert = new DateTime(2022, 06, 22), dateDelivery = new DateTime(2022, 07, 02), remarks = "All are packet" }
                );

            modelBuilder.Entity<DriverModelDal>().HasData(
                new DriverModelDal { id_drive = 1, name = "Alphonso", email = "alphonso@sctrans.com", phoneNumber = "06323156" },
                new DriverModelDal { id_drive = 2, name = "Karl", email = "Karl@gemini.com", phoneNumber = "09283921" }
                );

            modelBuilder.Entity<TransporterModelDal>().HasData(
                new TransporterModelDal { id_transporter = 1, name = "sctrans", adress = "rue des alouettes ", email = "info@sctrans.com", phoneNumber = "06273321" },
                new TransporterModelDal { id_transporter = 2, name = "geminitransport", adress = "rue des avions ", email = "info@geminitransport.com", phoneNumber = "06982313" }
                );
        }

        public DbSet<UserDal>? user { get; set; }

        public DbSet<CustomerModelDal>? customer { get; set; }

        public DbSet<DeliveryModelDal>? delivery { get; set; }

        public DbSet<DriverModelDal>? driver { get; set; }

        public DbSet<TransporterModelDal>? transporter { get; set; }

    }
}
