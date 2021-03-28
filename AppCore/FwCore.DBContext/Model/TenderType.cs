using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
  public class TenderType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcurementId { get; set; }

        [Required]
        public string ProcurementType { get; set; }

        public virtual Tenders tender { get; set; }


    }
}
