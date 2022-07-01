using DAL.data;
using DAL.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.services
{
    public class TransporterServiceDal
    {
        // 1) Faire connection String
        public string _cnstr;

        // 2) Créaction du construteur
        public TransporterServiceDal(string cnstr)
        {
            _cnstr = cnstr;
        }

        public void Create(TransporterModelDal transporter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    db.transporter.Add(transporter);
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception("Failed, driver not added.");
                }
            }
        }


        public void Delete(int idtr)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var trans = db.transporter.Where(tr => tr.id_transporter == idtr).FirstOrDefault();
                if (trans != null)
                {
                    db.transporter.Remove(trans);
                }
            }
        }

        public ICollection<TransporterModelDal> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                List<TransporterModelDal> transporters = db.transporter.ToList();
                return transporters;
            }
        }

        /// <summary>
        /// Return transporter by id
        /// </summary>
        /// <param name="idtr"></param>
        /// <returns></returns>
        /// 
        public TransporterModelDal GetById(int idtr)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var transporter = db.transporter.Where(tr => tr.id_transporter == idtr).FirstOrDefault();
                return transporter;
            }
        }

        public void Update(TransporterModelDal transporter, int idtr)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                {
                    var transdb = db.transporter?.FirstOrDefault(tr=> tr.id_transporter.Equals(idtr)); ;
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update transporter error it didn't work");
            }
        }

        /// <summary>
        /// Update drivers
        /// </summary>
        /// <param name="transportDriver"></param>
        /// <param name="idtrans"></param>
        /// <exception cref="Exception"></exception>

        public void UpdateTransporterDrivers(DriverModelDal transportDriver, int idtrans) 
        {
            try
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    var transporterDb = db.transporter?.Include(tr => tr.drivers).FirstOrDefault(t => t.id_transporter == idtrans);

                    transporterDb.drivers?.Add(transportDriver);

                    db.SaveChanges();
                }   
            }
            catch
            {
                throw new Exception(" Cannot update driver for the transporter Model ");
            }
        }

        /// <summary>
        /// Create driver and transporter relationship by Id
        /// </summary>
        /// <param name="idtrans"></param>
        /// <param name="iddrive"></param>
        /// <exception cref="Exception"></exception>
        /// 
        public void CreateTransporterDriversById( int idtrans, int iddrive)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var transId = new SqlParameter("@transId", idtrans);

                    var driveId = new SqlParameter("@driveId", iddrive);

                    var commandText = "INSERT INTO [dbo].[DriverModelDalTransporterModelDal] ([driversid_drive],[transportersid_transporter]) VALUES( @driveId, @transId )";

                    db.Database.ExecuteSqlRaw(commandText, driveId, transId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Error, Cannot create new transporter_driver relation.");
            }
        }

        /// <summary>
        ///  Update existing relationship for transporter_driver 
        /// </summary>
        /// <condition> Must have an existing relation in join_table unless the function won't work. </condition>
        /// <param name="idtrans"></param>
        /// <param name="iddrive"></param>
        /// <exception cref="Exception"></exception>
        /// 
        public void UpdateTransporterDriversById(int idtrans, int iddrive)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var transId = new SqlParameter("@transId", idtrans);

                    var driveId = new SqlParameter("@driveId", iddrive);

                    var commandText = "UPDATE [dbo].[DriverModelDalTransporterModelDal] SET[driversid_drive] = @driveId WHERE[transportersid_transporter] = @transId";

                    db.Database.ExecuteSqlRaw(commandText, driveId, transId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Error, Cannot Update transporter_driver relationship.");
            }
        }

    }
}
