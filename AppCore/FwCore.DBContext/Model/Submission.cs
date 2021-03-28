using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; }

        [Required]
        public double quentity { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("TenderID")]
        public int TenderID { get; set; }
        public virtual Tenders tender { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public  virtual  ICollection <ProductList> productList { get; set; }
    
    }
}
