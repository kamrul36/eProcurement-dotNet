using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class ProductList
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public Double   Quentity { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string Discription { get; set; }

        [ForeignKey("TenderID")]
        public int  TenderID { get; set; }
        public virtual Tenders Tender { get; set; }

        public virtual Submission Submission { get; set; }
      

    }
}
