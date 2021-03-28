using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Submits
{
   public class NewGood
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsId { get; set; }

        [Required]
        public string GoodsName { get; set; }

        [Required]
        public double quentity { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey("SubmitId")]
        public int? SubmitId { get; set; }

        public virtual SubmitGood Submit { get; set; }
    }
}
