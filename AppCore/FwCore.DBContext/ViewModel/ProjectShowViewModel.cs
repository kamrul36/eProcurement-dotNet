using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class ProjectShowViewModel
    {
        [Required]


        public int tenderID { get; set; }
        public string TenderTitle { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime TenderBeginDate { get; set; }

        public DateTime TenderSubmitEndDate { get; set; }




      
    }
}
