using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class Goods
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
        



    }
}
