using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryDtos
{
    public class CreateCategoryDto : IDto
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
