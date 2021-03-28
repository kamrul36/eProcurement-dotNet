using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FwCore.DBContext.Model
{
  public  class Profile
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]

        public string CompanyName { get; set; }

        [Required]
        public string CompanyCategory { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string TradeLicenseNo { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public string ProductSpecification { get; set; }


    }
}
