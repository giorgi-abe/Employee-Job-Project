using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainModels.Models;
using ApplicationDtos.ViewDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _repository = default;

        public EmployeeController(IRepository<Employee> repository, IMapper Mapper)
        {
            _mapper = Mapper;
            _repository = repository;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewDto>> Get()
        {
            var data = await _repository.Get().Include("Numbers").ToListAsync();
            var returnData = _mapper.Map<IEnumerable<EmployeeViewDto>>(data);
            return returnData;
        }
        // GET api/Employee/5
        [HttpGet("{id}")]
        public async Task<EmployeeViewDto> Get(int id)
        {
            var obj = _repository.Get().Include("Numbers").FirstOrDefault( o => o.Id == id);
            return _mapper.Map<EmployeeViewDto>(obj);
        }
        // POST api/Employee/Add
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeViewDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var result = await _repository.CreateAsync(_mapper.Map<Employee>(item));
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

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeViewDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var result = await _repository.UpdateAsync(id, _mapper.Map<Employee>(item));
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
        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
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
