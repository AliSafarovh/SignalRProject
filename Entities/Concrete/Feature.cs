using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Feature : IEntity
    {
        public int FeatureId { get; set; }
        public List<FeatureDescripition> Descripitions { get; set; }

        public Feature()
        {
            Descripitions = new List<FeatureDescripition>();
        }
        
    }
  

}