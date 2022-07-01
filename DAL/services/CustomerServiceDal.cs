using DAL.data;
using DAL.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.services
{
    public class CustomerServiceDal
    {
        // 1) Faire connection String
        public string _cnstr;

        // 2) Créaction du construteur
        public CustomerServiceDal(string cnstr)
        {
            _cnstr = cnstr;
        }

        // 3) Injecter la connection string dans le dbContext
        public void Create(CustomerModelDal customer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    db.customer?.Add(customer);
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception("Failed, customer not added.");
                }

            }
        }

        public void Delete(int idc)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var cu = db.customer?.Where(c => c.id_customer == idc).FirstOrDefault();
                if (cu != null)
                {
                    db.customer?.Remove(cu);
                }
            }
        }

        public IEnumerable<CustomerModelDal> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                IEnumerable<CustomerModelDal> cus = db.customer?.ToList();
                return cus;
            }
        }

        // Gett all + foreign table
/*        public IEnumerable<CustomerModelDal> GetAllTables()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var cus = db.customer?.Include(c=>c.deliveries)?.ThenInclude(c=>c.transporters)?.ThenInclude(c=>c.drivers)?.ToList();
                return cus;
            }
        }*/

        // Return by id

        public CustomerModelDal GetById(int idc)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var cu = db.customer?.Where(c => c.id_customer == idc).FirstOrDefault();
                return cu;
            }
        }

        // Update delivery relationship

        // PRECISION: You can add with N:N relation only with ICollection because Add() is Only available on Collection
        // IEnumerable can only read NOT Add !!
        public void UpdateCustomerDeliveries(DeliveryModelDal cusDeliveries, int idc)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {   
                    // Create Link between customer model and the delivery model
                    var cudeldb = db.customer?.Include(c => c.deliveries).FirstOrDefault(c => c.id_customer == idc);

                    // Then add the model with Add
                    cudeldb.deliveries?.Add(cusDeliveries);
                    
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }

        // Update existing Deliveries id with customer id

        public void CreateCustomerDelivery(int idc, int iddel)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    var deliverydb = db.customer?.Include(c => c.deliveries.Where(c => c.id_delivery == iddel)).FirstOrDefault(c => c.id_customer == idc);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }


        // Create a new relation for join table relationship
        public void CreateCustomerDeliveryById(int idc, int iddel)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var customerId = new SqlParameter("@customerId", idc);

                    var deliveryId = new SqlParameter("@deliveryId", iddel);

                    var commandText = " INSERT INTO[dbo].[CustomerModelDalDeliveryModelDal] ([customersid_customer],[deliveriesid_delivery]) VALUES ( @customerId , @deliveryId ) ";

                    db.Database.ExecuteSqlRaw(commandText, customerId, deliveryId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }

        // Update an existing join table relationship
        public void UpdateCustomerExistingDeliveryById(int idc, int iddel)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {   
                    var customerId = new SqlParameter("@customerId", idc);

                    var deliveryId = new SqlParameter("@deliveryId", iddel);

                    var commandText = "UPDATE [dbo].[CustomerModelDalDeliveryModelDal] SET[deliveriesid_delivery] = @deliveryId  WHERE CustomerModelDalDeliveryModelDal.customersid_customer = @customerId";

                    db.Database.ExecuteSqlRaw(commandText, customerId, deliveryId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }


        public void Update(CustomerModelDal customer, int idc)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                {
                    var cudb = db.customer?.FirstOrDefault(c => c.id_customer.Equals(idc));

                    cudb.name = customer.name;

                    cudb.vat = customer.vat;

                    cudb.email = customer.email;

                    cudb.adress = customer.adress;

                    cudb.phoneNumber = customer.phoneNumber;

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
