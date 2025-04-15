using Core.Entities;

namespace WebUI.DTOs.CategoryDto
{
    public class GetByIdCategoryDto 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
