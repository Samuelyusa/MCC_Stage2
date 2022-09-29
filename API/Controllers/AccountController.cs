using API.Models;
using API.Repositories.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if (data != null)
                return Ok(new { message = "berhasil Login", statusCode = 200, data = data });
            return BadRequest(new { message = "gagal Login, cek email & password", statusCode = 400 });
        }
        [HttpPost("Register")]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data != null)
                return Ok(new { message = "Register Success", statusCode = 200, data = data });
            return BadRequest(new { message = "Register Failed", statusCode = 400 });
        }
    }
}
