using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class TenderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        public string TGoodsName { get; set; }

        [ForeignKey("TenderID")]
        public int? TenderID { get; set; }
        public virtual Tenders tender { get; set; }
    }
}
