using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Submits
{
  public  class SubmitGood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmitId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string TenderRefNumber { get; set; }


        [Required]
        public string TenderTitle { get; set; }

        [Required]
        public double TotalPrice { get; set; }



        public virtual List<NewGood> Goods { get; set; }
    }
}
