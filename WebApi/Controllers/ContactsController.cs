using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
            var result = await _contactService.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetContactDto>>(result.Data);
            var dataResult = new DataResult<List<GetContactDto>>(mappedResult, result.Success);
            return result.Success ? Ok(dataResult) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            var mappedResult = _mapper.Map<GetByIdContactDto>(result.Data);
            var dataResult = new DataResult<GetByIdContactDto>(mappedResult, result.Success);
            return result.Success ? Ok(result) : NotFound(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var data = _mapper.Map<Contact>(createContactDto);
            var result = await _contactService.AddAsync(data);
            return result.Success ? Ok(data) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContcatDto)
        {
            var data = _mapper.Map<Contact>(updateContcatDto);
            var result = await _contactService.UpdateAsync(data);
            return result.Success ? Ok(Messages.ProductUpdated) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _contactService.GetByIdAsync(id);
            await _contactService.DeleteAsync(value.Data);
            return Ok(Messages.ProductDeleted);
        }

    }
}
