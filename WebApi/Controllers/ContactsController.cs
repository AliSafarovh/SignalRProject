using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Entities.DTOs.ContactDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _contactService.GetAllAsync();
            return values.Success ? Ok(values) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _contactService.GetByIdAsync(id);
            return value.Success ? Ok(value.Data) : NotFound(value.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromForm] CreateContactDto createContactDto)
        {
            var result = await _contactService.AddAsync(_mapper.Map<Contact>(createContactDto));
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromForm] UpdateContactDto updateContcatDto)
        {
            var result = await _contactService.UpdateAsync(_mapper.Map<Contact>(updateContcatDto));
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _contactService.GetByIdAsync(id);
            await _contactService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }

    }
}
