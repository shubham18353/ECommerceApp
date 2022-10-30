using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessObjects
{
   public class Category
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
