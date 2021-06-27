using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Models
{
    public class ShopCategory
    {
        [Key]
        public int ShopCategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Shop Category Name")]
        public string ShopCategoryName { get; set; }

        public virtual ICollection<ClothInfo> ShopCategoryClothInfos { get; set; }
    }
}
