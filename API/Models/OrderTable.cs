namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderTable")]
    public partial class OrderTable
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string OrderDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ProdID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string CustID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string ShippingMode { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(100)]
        public string ShipDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}
