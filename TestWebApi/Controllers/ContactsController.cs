using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestWebApi.Domain.Entities;
using TestWebApi.Helpers;
using TestWebApi.Services;
using TestWebApi.Services.Dtos;

namespace TestWebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ContactsController : Controller
    {
        private IContactService _contactService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ContactsController(
            IContactService contactService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _contactService = contactService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("/contacts")]
        public IActionResult Register([FromBody]ContactDto contactDto)
        {
            // map dto to entity
            var contact = _mapper.Map<Contact>(contactDto);

            try
            {
                // save - this is where a user is created
                _contactService.Create(contact);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/contacts")]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll();
            var contactDtos = _mapper.Map<IList<ContactDto>>(contacts);
            return Ok(contactDtos);
        }

        [HttpGet("/contacts/{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactService.GetById(id);
            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        [HttpDelete("/contacts/{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok();
        }
    }
}
