using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Models
{
    public class ClothInfo
    {
        [Key]
        public int ClothInfoID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Cloth Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float ClothPrice { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Cloth Size Chart")]
        public string SizeChart { get; set; }


        [Required]
        [StringLength(1500)]
        [Display(Name = "Feature")]
        public string Feature { get; set; }

        [Required]
        public int ShopCategoryID { get; set; }

        [ForeignKey("ShopCategoryID")]
        [InverseProperty("ShopCategoryClothInfos")]
        public virtual ShopCategory ShopCategory { get; set; }

        [Required]
        public int ClothCompanyID { get; set; }

        [ForeignKey("ClothCompanyID")]
        [InverseProperty("CompanyClothInfos")]
        public virtual ClothCompany ClothCompany { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public ClothPhoto File { get; set; }

        public virtual ICollection<CartItem> ClothCartItems { get; set; }
    }
    public class ClothPhoto
    {
        [Required]
        [Display(Name = "Cloth Photo")]
        public IFormFile FormFile { get; set; }
    }
}
