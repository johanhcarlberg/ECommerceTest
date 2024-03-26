using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTest.Shared.Dtos
{
    public class ProductDto
    {
        [Required, StringLength(25, MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        [Required, DataType(DataType.Currency)]
        public int Price { get; set; }
    }
}
