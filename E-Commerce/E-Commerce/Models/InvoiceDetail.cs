namespace E_Commerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int? Promotion { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }

        public virtual Promotion Promotion1 { get; set; }
    }
}
