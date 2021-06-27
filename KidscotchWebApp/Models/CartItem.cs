using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KidscotchWebApp.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [Required]
        public int CartID { get; set; }

        [ForeignKey("CartID")]
        [InverseProperty("CartCartItems")]
        public virtual CartInfo CartInfo { get; set; }

        [Required]
        public int ClothInfoID { get; set; }

        [ForeignKey("ClothInfoID")]
        [InverseProperty("ClothCartItems")]
        public virtual ClothInfo ClothInfo { get; set; }

        [Display(Name = "Cloth Price")]
        public float Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Total Price")]
        public float Total { get; set; }
    }
}
