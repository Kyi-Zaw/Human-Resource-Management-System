using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeInfo employee;

        public EmployeeController(IEmployeeInfo employee)
        {
            this.employee = employee;
        }
        [Authorize(Policy = "ControllerAccess")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data =await employee.GetAllAsync();
            return Ok(data);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var data =await employee.GetByIDAsync(id);
            return Ok(data);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeInfoRequest employee)
        {
            var result =await this.employee.AddAsync(employee);
            return Ok(result);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,[FromBody] EmployeeInfoRequest employeeInfoRequest)
        {
            var result = await this.employee.UpdateAsync(id,employeeInfoRequest);
            return Ok(result);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await employee.DeleteAsync(id);
            return Ok(result);
        }

    }
}
