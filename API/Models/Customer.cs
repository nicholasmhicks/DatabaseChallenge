namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            OrderTables = new HashSet<OrderTable>();
        }

        [Key]
        [StringLength(100)]
        public string CustID { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string State { get; set; }

        public int PostCode { get; set; }

        public int? SegID { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        public virtual Segment Segment { get; set; }

        public virtual Region Region1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
