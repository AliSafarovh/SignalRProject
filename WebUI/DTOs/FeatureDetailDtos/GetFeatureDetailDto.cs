﻿namespace WebUI.DTOs.FeatureDetailDtos
{
    public class GetFeatureDetailDto 
    {
        public int FeatureDetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FeatureId { get; set; }
    }
}
