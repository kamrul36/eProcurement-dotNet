using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.ViewModel
{
  public  class SubmitViewModel
    {

        [Required]
        public int SubmitId { get; set; }

        [Required]
        public string TenderRefNumber { get; set; }


        [Required]
        public string TenderTitle { get; set; }


        [Required]
        public string GoodsName { get; set; }

        [Required]
        public double quentity { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double TotalPrice { get; set; }
    }
}
