using AspApiCoreapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AspApiCoreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly tempdbContext tdb;

        public StudentsController(tempdbContext tdb)
        {
            this.tdb = tdb;
        }

        [HttpGet]
        public ActionResult getEmployees()
        {
            var data=tdb.Employees.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult getEmployeebyID(int id)
        {
            var data = tdb.Employees.FindAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public ActionResult modifyEmployee(int id ,Employee employee) 
        {
            if (id != employee.Id)
            {
                return BadRequest();            }
           tdb.Entry(employee).State= EntityState.Modified;
            tdb.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult createEmployee(Employee emp)
        {
            var data=tdb.Employees.AddAsync(emp);
            tdb.SaveChangesAsync();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            var employee = await tdb.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(); 
            }

            tdb.Employees.Remove(employee);
            await tdb.SaveChangesAsync();

            return Ok();
        }

    }
}
