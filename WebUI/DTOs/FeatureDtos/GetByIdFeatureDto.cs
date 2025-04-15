using Entities.Concrete;

namespace WebUI.DTOs.FeatureDtos
{
    public class GetByIdFeatureDto 
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public List<FeatureDetail> Descripitions { get; set; }

    }
}
