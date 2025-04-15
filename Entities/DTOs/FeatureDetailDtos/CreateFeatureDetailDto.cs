using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.FeatureDetailDtos
{
    public class CreateFeatureDetailDto:IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int FeatureId { get; set; }
    }
    
}
