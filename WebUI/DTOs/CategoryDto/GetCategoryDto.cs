﻿using Core.Entities;

namespace WebUI.DTOs.CategoryDto
{
    public class GetCategoryDto 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
