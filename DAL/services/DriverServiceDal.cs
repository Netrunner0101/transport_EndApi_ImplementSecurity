using DAL.data;
using DAL.models;

namespace DAL.services
{
    public class DriverServiceDal
    {

        // 1) Faire connection String
        public string _cnstr;

        // 2) Créaction du construteur
        public DriverServiceDal(string cnstr)
        {
            _cnstr = cnstr;
        }

        public void Create(DriverModelDal driver)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    db.driver.Add(driver);
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception("Failed, driver not added.");
                }
            }
        }


        public void Delete(int iddriver)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var dri = db.driver.Where(dr => dr.id_drive== iddriver).FirstOrDefault();
                if (dri != null)
                {
                    db.driver.Remove(dri);
                }
            }
        }

        public ICollection<DriverModelDal> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                List<DriverModelDal> drivers = db.driver.ToList();
                return drivers;
            }
        }

        // Return by id
        public DriverModelDal GetById(int iddriver)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var driver = db.driver.Where(ds => ds.id_drive == iddriver).FirstOrDefault();
                return driver;
            }
        }

        // Return by name
        public DriverModelDal GetByName(string name)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var driver = db.driver.Where(ds => ds.name == name).FirstOrDefault();
                return driver;
            }
        }

        public void Update(DriverModelDal driver, int iddriver)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                {
                    var driverdb = db.driver.FirstOrDefault(ds => ds.id_drive.Equals(iddriver)); 
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update error it didn't work");
            }

        }


    }
}
