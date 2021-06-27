using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Models
{
    public class ClothCompany
    {
        [Key]
        public int ClothCompanyID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Cloth Company Name")]
        public string ClothCompanyName { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "About Company")]
        public string About { get; set; }

        public virtual ICollection<ClothInfo> CompanyClothInfos { get; set; }
    }
}
