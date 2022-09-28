using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentRepository departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = departmentRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "Data yang ada minta Tidak Ada", statusCode = 200, data = data });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = departmentRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Data yang anda ambil TIDAK ADA", statusCode = 200, data = data });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Department department)
        {
            var result = departmentRepository.Put(department);
            if (result > 0)
                return Ok(new { message = "Berhasil mengubah data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal mengubah data", statusCode = 400 });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Department department)
        {
            var result = departmentRepository.Post(department);
            if (result > 0)
                return Ok(new { message = "Berhasil menambahkan data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal menambahkan data", statusCode = 400 });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = departmentRepository.Delete(id);
            if (result > 0)
                return Ok(new { message = "Berhasiil menghapus data", statusCode = 200 });
            return Ok(new { message = "Gagal menghapus data", statusCode = 200 });
        }

    }
}
