using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using EmployeeManagement.Repositories;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;

        public EmployeesController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            await _repository.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            await _repository.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
