using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
  public class SubmissionViewModel
    {


        //public string productList { get; set; }

        [Required]
        public double quentity { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
