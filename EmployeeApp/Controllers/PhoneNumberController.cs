using ApplicationDomainCore.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDtos.ViewDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _employeeRepository = default;
        private readonly IRepository<PhoneNumber> _phoneNumberRepository = default;

        public PhoneNumberController(IRepository<Employee> EmployeeRepository, IMapper Mapper, IRepository<PhoneNumber> PhoneNumberRepository)
        {
            _mapper = Mapper;
            _employeeRepository = EmployeeRepository;
            _phoneNumberRepository = PhoneNumberRepository;
        }

        // GET: api/PhoneNumber
        [HttpGet]
        public async Task<IEnumerable<PhoneNubmerViewDto>> Get()
        {
            var data = await _phoneNumberRepository.ReadAsync();
            var returnData = _mapper.Map<IEnumerable<PhoneNubmerViewDto>>(data);
            return returnData;
        }
        // GET api/PhoneNumber/5
        [HttpGet("{id}")]
        public async Task<PhoneNubmerViewDto> Get(int id)
        {
            var obj = await _phoneNumberRepository.ReadByIdAsync(id);
            return _mapper.Map<PhoneNubmerViewDto>(obj);
        }
        // POST api/PhoneNumber
        [HttpPost("{Employeeid}")]
        public async Task<IActionResult> Post(int Employeeid, [FromBody] PhoneNubmerViewDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var Number = _mapper.Map<PhoneNumber>(item);
                Number.EmployeeId = Employeeid;
                var result = await _phoneNumberRepository.CreateAsync(Number);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }

        // PUT api/PhoneNumber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int employeeid, [FromBody] PhoneNubmerViewDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var obj = _mapper.Map<PhoneNumber>(item);
                obj.EmployeeId = employeeid;
                var result = await _phoneNumberRepository.UpdateAsync(id, obj);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }
        // DELETE api/PhoneNumber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _phoneNumberRepository.DeleteAsync(id);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }
    }
}
