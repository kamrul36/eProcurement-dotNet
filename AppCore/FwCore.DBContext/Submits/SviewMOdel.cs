using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Submits
{
 public   class SviewMOdel
    {
        public int SubmitId { get; set; }

        
        public string CompanyName { get; set; }


        public string TenderRefNumber { get; set; }


   
        public string TenderTitle { get; set; }


    
        public string GoodsName { get; set; }

        public double quentity { get; set; }
      
        public double Price { get; set; }

   

        public double TotalPrice { get; set; }

    }
}
