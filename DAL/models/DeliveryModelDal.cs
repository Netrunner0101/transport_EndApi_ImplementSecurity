using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.models
{
    [Table("delivery")]
    public class DeliveryModelDal
    {

        public DeliveryModelDal(int id_delivery, string? numeroDelivery , int? weight, string? adress, DateTime? dateTransfert, DateTime? dateDelivery, string? remarks, ICollection<TransporterModelDal>? transporters, ICollection<CustomerModelDal>? customers)
        {
            this.id_delivery = id_delivery;

            this.numeroDelivery = numeroDelivery;

            this.weight = weight;
            
            this.adress = adress;
            
            this.dateTransfert = dateTransfert;
            
            this.dateDelivery = dateDelivery;
            
            this.remarks = remarks;
            
            this.customers = customers;
            
            this.transporters = transporters;
        }

        public DeliveryModelDal()
        {

        }

        [Key]
        public int id_delivery { get; set; }

        [Required]

        public string? numeroDelivery { get; set; }

        public int? weight { get; set; }

        public string? adress { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dateTransfert { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dateDelivery { get; set; }

        [MaxLength(500)]
        public string? remarks { get; set; }

        // relation n:n
        public ICollection<TransporterModelDal>? transporters { get; set; }

        // relation n:n
        public ICollection<CustomerModelDal>? customers { get; set; }

        public static explicit operator DeliveryModelDal(CustomerModelDal? v)
        {
            throw new NotImplementedException();
        }
    }
}
