using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.FeatureDtos
{
    public class CreateFeatureDto : IDto
    {
        public string FeatureName { get; set; }
    }
}
