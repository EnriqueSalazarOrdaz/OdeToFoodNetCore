using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class RestaurantEditModel
    {
        [Required(ErrorMessage ="Requerido"),MaxLength(80,ErrorMessage ="just 80 characters")]
        public string Name { get; set; }
        public CusineType Cusine { get; set; }
    }
}
