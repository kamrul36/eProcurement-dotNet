using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class TenderViewModel
    {
        public int TenderID { get; set; }

        [Required]
        public string TenderRefNumber { get; set; }

        [Required]
        public string TenderTitle { get; set; }

        [Required]
        public string ProcurementType { get; set; }

        [Required]
        public string CategoryType { get; set; }

        [Required]
        public string DocumentUpdload { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool AllowReSubmission { get; set; }

        public bool IsActive { get; set; }

        public string PaymentType { get; set; }

        [Required]
        public string ContactType { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]

        public double PTotalCost { get; set; }

        public string TGoodsName { get; set; }


        [Required]
        public DateTime BidOpeningDate { get; set; }

        [Required]
        public DateTime BidClosingDate { get; set; }


        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string StatusType { get; set; }

    }
}
