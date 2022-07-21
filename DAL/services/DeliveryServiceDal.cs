using DAL.data;
using DAL.models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DeliveryModelDal = DAL.models.DeliveryModelDal;

namespace DAL.services
{
    public class DeliveryServiceDal
    {

        // 1) Faire connection String
        public string _cnstr;

        // 2) Créaction du construteur
        public DeliveryServiceDal(string cnstr)
        {
            _cnstr = cnstr;
        }

        // 3) Injecter la connection string dans le dbContext
        public void Create(DeliveryModelDal delivery)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                try
                {
                    db.delivery.Add(delivery);
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception("Failed, delivery not added.");
                }
            }
        }


        public async void Delete(int idd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var de = db.delivery.Where(d => d.id_delivery == idd).FirstOrDefault();
                if (de != null)
                {
                    db.delivery.Remove(de);
                    await db.SaveChangesAsync();
                }
            }
        }

        public ICollection<DeliveryModelDal> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                List<DeliveryModelDal> des = db.delivery.ToList();
                return des;
            }
        }

        // Get transporter for specific delivery
        public DeliveryModelDal GetDeliveryTransporterId(int iddel )
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var transporter = db.delivery?.Where(d=>d.id_delivery == iddel).Include(d => d.transporters).FirstOrDefault();

                return transporter;
            }
        }

        // Return by id
        public DeliveryModelDal GetById(int idd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var des = db.delivery.Where(ds => ds.id_delivery == idd).FirstOrDefault();
                return des;
            }
        }

        // Return by delivery code
        public DeliveryModelDal GetByCode(string codeDel)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
            {
                var des = db.delivery.Where(ds => ds.numeroDelivery == codeDel).FirstOrDefault();
                return des;
            }
        }

        public void Update(DeliveryModelDal delivery, int idd)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext(_cnstr))
                {
                    var dsdb = db.delivery.FirstOrDefault(ds => ds.id_delivery.Equals(idd));

                    dsdb.numeroDelivery = delivery.numeroDelivery;
                    
                    dsdb.weight = delivery.weight;  
                    
                    dsdb.adress = delivery.adress;
                    
                    dsdb.remarks = delivery.remarks;

                    dsdb.dateTransfert = delivery.dateTransfert;
                    
                    dsdb.dateDelivery = delivery.dateDelivery;

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update driver error it didn't work ");
            }

        }

        // update remarks
        public void UpdateRemarks(string remarks,int iddel)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var deldbremark = db.delivery?.FirstOrDefault(d => d.id_delivery == iddel);

                    deldbremark.remarks = remarks;

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Cannot update remarks");
            }
        }

        // update transporter
        public void UpdateDeliveryTransproter(TransporterModelDal delTrans, int idel)
        {
            try
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    var deliveryDb = db.delivery?.Include(d=>d.transporters).FirstOrDefault(d=>d.id_delivery == idel);

                    deliveryDb.transporters?.Add(delTrans);
                   
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("The Transporter is NOT update for Delivery.");
            }
        }

        // Insert transporter id with an specific id
        public void CreateDeliveryTransporter(int iddel, int idtrans)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var deliId = new SqlParameter("@deliId", iddel);

                    var transId = new SqlParameter("@transId", idtrans);

                    var commandText = "INSERT INTO [dbo].[DeliveryModelDalTransporterModelDal] ([deliveriesid_delivery],[transportersid_transporter]) VALUES (@deliId, @transId)";

                    db.Database.ExecuteSqlRaw(commandText, deliId, transId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }

        // Update transporter id with an specific id
        public void UpdateDeliveryTransporter(int iddel, int idtrans)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var deliId = new SqlParameter("@deliId", iddel);

                    var transId = new SqlParameter("@transId", idtrans);

                    var commandText = "UPDATE [dbo].[DeliveryModelDalTransporterModelDal] SET[transportersid_transporter] = @transId WHERE[deliveriesid_delivery] = @deliId";

                    db.Database.ExecuteSqlRaw(commandText, deliId, transId);

                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Update deliveries error it didn't work");
            }
        }


        // update customer
 /*       public void UpdateDeliveryCustomers(CustomerModelDal delCus, int idel)
        { 
            try
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    var deliveryDb = db.delivery?.Include(d => d.customers).FirstOrDefault(d => d.id_delivery == idel);
                    deliveryDb?.customers?.Add(delCus);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("The Customer is NOT update for Delivery.");
            }

        }*/



    }
}
