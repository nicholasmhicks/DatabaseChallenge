namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderTables = new HashSet<OrderTable>();
        }

        [Key]
        [StringLength(100)]
        public string ProdID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitPrice { get; set; }

        public int? Category { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
