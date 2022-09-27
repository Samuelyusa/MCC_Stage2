using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        MyContext myContext;

        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Employees.ToList();
            if (data.Count == 0)
                return Ok(new { message = "Data yang anda ambil TIDAK ADA", statusCode = 200, data = data });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Employees.Find(id);
            if (data == null)
                return Ok(new { message = "Data yang anda ambil TIDAK ADA", statusCode = 200, data = data });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            var data = myContext.Employees.Find(id);
            data.FirstName = employee.FirstName;
            myContext.Employees.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal mengambil data", statusCode = 400 });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            myContext.Employees.Add(employee);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Berhasil menambahkan data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal menambahkan data", statusCode = 400 });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Employees.Find(id);
            myContext.Employees.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Berhasiil menghapus data", statusCode = 200});
            return Ok(new { message = "Gagal menghapus data", statusCode = 200});
        }
    }
}
