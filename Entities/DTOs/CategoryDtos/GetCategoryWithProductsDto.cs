using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryDtos
{
    public class GetCategoryWithProductsDto:IDto
    {
        public string Name { get; set; }
        public List<string> ProductNames{ get; set; }

    }
}
