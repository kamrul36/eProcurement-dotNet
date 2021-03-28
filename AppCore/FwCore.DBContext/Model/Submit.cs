using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
  public  class Submit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmitId { get; set; }


        [Required]
        public double TotalPrice { get; set; }


        [ForeignKey("TenderID")]
        public int? TenderID { get; set; }
        public virtual Tenders tender { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual ICollection<ProductList> productList { get; set; }

        [ForeignKey("GoodsId")]
        public int? GoodsId { get; set; }
        public virtual List<Goods> Goods { get; set; }
    }
}
