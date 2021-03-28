using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
    public  class Tenders
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TenderID { get; set; }

        [Required]
        public string TenderTitle { get; set; }

        [Required]
        public string TenderRefNumber { get; set; }

        [Required]
        public string DocumentUpdload { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
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


        public virtual ICollection<TenderProduct> TenderProducts { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BidOpeningDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BidClosingDate { get; set; }

        [ForeignKey("StatusID")]
        public int? StatusID { get; set; }
        public virtual Status status { get; set; }

        public virtual List<ProductList> productList { get; set; }

        [ForeignKey("ProcurementId")]
        public int ? ProcurementId { get; set; }
        public virtual TenderType tenderType { get; set; }

        [ForeignKey("CatId")]
        public int CatId { get; set; }
        public virtual TenderCategory tenderCategory { get; set; }

        public virtual Submit Submit { get; set; }


       



    }
}
